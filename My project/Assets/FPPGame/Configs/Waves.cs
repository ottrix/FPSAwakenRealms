using System.Collections.Generic;
using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "Waves", menuName = "Configs/Waves")]
    public class Waves : ScriptableObject
    {
        public List<Wave> Wave;
    }
}