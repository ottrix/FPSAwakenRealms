using UnityEngine;

namespace FPPGame
{
    public class EnemySpawner
    {
        public int CurrentWave;
        public int EnemiesSpawned;
        public int EnemiesKilled;
        public bool IsWaveActive;
        
        public void SpawnEnemy(Vector3 position, GameObject prefab)
        {
            ObjectPoolManager.GetObject<Enemy>(prefab).transform.position = position;
        }
    }
}