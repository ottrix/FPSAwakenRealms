using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]

    public class MainConfig : ScriptableObject
    {
      public MainCharacterConfig MainCharacterConfig;
      public WeaponsConfig WeaponsConfig;
      public EnemiesConfig EnemiesConfig;
    }
}