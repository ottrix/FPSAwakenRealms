using UnityEngine;

namespace FPPGame
{
    public class PoofSpawner
    {
        public void SpawnPoof(Vector3 position, GameObject prefab)
        {
            Debug.Log($"{position} before spawn");
            var poof = ObjectPoolManager.GetObject<Poof>(prefab);
            poof.Setup(position);
        }
        
    }
}