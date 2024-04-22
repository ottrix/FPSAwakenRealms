using System.Collections.Generic;
using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configs/EnemiesConfig")]
    public class EnemiesConfig : ScriptableObject
    {
        public List<EnemyConfig> Enemies;
        public List<Wave> Waves;
    }
}