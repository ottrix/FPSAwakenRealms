using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public GameObject EnemyPrefab;
        public int Id;
    }
}