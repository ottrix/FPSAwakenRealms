using System.Collections.Generic;
using UnityEngine;

namespace FPPGame
{
    public class EnemySpawnBehaviour : MonoBehaviour
    {
        private EnemiesConfig _enemiesConfig => GameManager.MainConfig.EnemiesConfig;
        [SerializeField] private List<Transform> _spawnPoints;
        private int _currentWave => GameManager.EnemySpawner.CurrentWave;

        private void OnEnable()
        {
            EventsManager.OnWaveStarted += OnWaveStarted;
        }
        
        private void OnDisable()
        {
            EventsManager.OnWaveStarted -= OnWaveStarted;
        }
        
        private void OnWaveStarted()
        {
            if (GameManager.EnemySpawner.IsWaveActive == false)
            {
                GameManager.EnemySpawner.IsWaveActive = true;
            }
                
            int enemyCount = _enemiesConfig.Waves[_currentWave].EnemyCount;
            for (int i = 0; i < enemyCount; i++)
            {
                if (GameManager.EnemySpawner.IsWaveActive)
                {
                    SpawnEnemy();
                    GameManager.EnemySpawner.EnemiesSpawned++;
                }
            }
        }
        
     
        
        private void SpawnEnemy()
        {
            int randomEnemyIndex = Random.Range(0, _enemiesConfig.Enemies.Count);
            GameObject enemyPrefab = _enemiesConfig.Enemies[randomEnemyIndex].EnemyPrefab;
            GameManager.EnemySpawner.SpawnEnemy(RandomSpawnPoint(), enemyPrefab);   
        }
        
        private Vector3 RandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count);
            return _spawnPoints[randomIndex].position;
        }
    }
}