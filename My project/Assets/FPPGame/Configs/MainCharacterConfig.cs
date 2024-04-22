using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "MainCharacterConfig", menuName = "Configs/MainCharacterConfig")]
    public class MainCharacterConfig : ScriptableObject
    {
        public float MoveSpeed = 4.0f;
        public float SprintSpeed = 6.0f;
        public float JumpHeight = 1.2f;
        public int MaxHealth;
        public int Damage;
        
        public int PowerAmountOnTheBeginning;
    }
}