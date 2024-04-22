using System.Collections.Generic;
using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "WeaponsConfig", menuName = "Configs/WeaponsConfig")]
    public class WeaponsConfig : ScriptableObject
    {
        public List<WeaponConfig> _weapons;
    }
}