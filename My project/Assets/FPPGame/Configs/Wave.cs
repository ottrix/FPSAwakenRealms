using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Configs/Wave")]
    public class Wave : ScriptableObject
    {
        [SerializeField] private int _waveNumber;
        public int EnemyCount;
        [SerializeField] private float _spawnRate;
    }
}