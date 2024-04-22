using UnityEngine;

namespace FPPGame
{
    public class Shard : MonoBehaviour
    {
        [SerializeField] private int powerAmount;
        [SerializeField] private AudioClip shardSound;
        private bool isCollected = false;
        
        private void OnEnable()
        {
            isCollected = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isCollected == false)
            {
                isCollected = true;
                AddPower();                
                if(shardSound == null)
                return;
                
                AudioSource.PlayClipAtPoint(shardSound, transform.position);
                returnToPool();
            }
        }
        
        private void AddPower()
        {
            GameManager.MainCharacter.addPower(powerAmount);
            EventsManager.PowerChanged?.Invoke();
        }
        
        private void returnToPool()
        {
            ObjectPoolManager.ReturnObject(this);
        }
    }
}