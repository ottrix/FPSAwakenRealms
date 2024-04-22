using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPPGame
{
    public class Enemy : MonoBehaviour
    {
        public GameObject Shard;
        public Animator EnemyAnimator;
        public float Damage;
        public float Health;
        public NavMeshAgent NavMeshAgent;
        public AudioClip HitSound;
        public AudioSource AudioSource;
        public AudioSource DeathSource;
        public List<AudioClip> DeathSounds;

        private GameObject PlayerCharacter;
        private bool _isDeath;

        private void Start()
        {
            PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        }
        
        // on trigger enter by spell1 tag
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Spell1"))
            {
                GetHit(20);
            }
        }

        private void Update()
        {
            if (PlayerCharacter == null || _isDeath)
                return;

            UpdateDestination();
            UpdateAttack();
            UpdateRunning();
        }

        private void UpdateDestination()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerCharacter.transform.position);

            if(NavMeshAgent == null)
            {
                return;
            }
            
            if (distanceToPlayer > 2)
            {
                NavMeshAgent.SetDestination(PlayerCharacter.transform.position);
            }
            else
            {
                NavMeshAgent.SetDestination(transform.position);
            }
        }
        
        

        private void UpdateAttack()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerCharacter.transform.position);

            if(EnemyAnimator == null)
            {
                return;
            }
            
            if (distanceToPlayer < 3)
            {
                EnemyAnimator.SetBool("isAttacking", true);
                transform.LookAt(PlayerCharacter.transform);
            }
            else
            {
                EnemyAnimator.SetBool("isAttacking", false);
            }
        }

        private void UpdateRunning()
        {
            if(EnemyAnimator == null)
            {
                return;
            }
            
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerCharacter.transform.position);

            if (distanceToPlayer > 3)
            {
                EnemyAnimator.SetBool("isRunning", true);
            }
            else
            {
                EnemyAnimator.SetBool("isRunning", false);
            }
        }
        
        public void GetHit(float damage)
        {
            if (_isDeath)
            {
                return;
            }
            AudioSource.PlayOneShot(HitSound);
            Health -= damage;
            Debug.Log($"Enemy got hit for {damage} damage. Health left: {Health} HP.");
            if (Health <= 0)
            {
                Debug.Log("Enemy died");
                EnemyAnimator.SetBool("isDeath", true);
                Invoke("ReturnEnemyToPool", 1.5f);
                Invoke("DropShard", 1.4f);
                _isDeath = true;
                DeathSource.PlayOneShot(DeathSounds[Random.Range(0, DeathSounds.Count)]);
                GameManager.EnemySpawner.EnemiesKilled++;

                if(GameManager.EnemySpawner.EnemiesKilled == GameManager.EnemySpawner.EnemiesSpawned)
                {
                    GameManager.EnemySpawner.IsWaveActive = false;
                    EventsManager.WaveEnded.Invoke();
                }
            }
        }
        
        private void DropShard()
        {
            GameManager.ShardSpawner.SpawnShard(transform.position, Shard);
        }
        
        private void ReturnEnemyToPool()
        {
            ObjectPoolManager.ReturnObject(this);
        }
    }
}