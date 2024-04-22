using UnityEngine;


namespace FPPGame
{
    public class ShardSpawner 
    {
        public void SpawnShard(Vector3 position, GameObject prefab)
        {
            position.y += 1;
            ObjectPoolManager.GetObject<Shard>(prefab).transform.position = position;
        }
    }
}
