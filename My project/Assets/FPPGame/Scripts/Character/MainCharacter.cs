using UnityEngine;

namespace FPPGame
{
    public class MainCharacter
    {
        public int Health;
        public int Power;
        public int Speed;
        
        public void SetupMainCharacter(int health, int power, int speed)
        {
            Health = health;
            Power = power;
            Speed = speed;
        }
        
        public void usePower()
        {
            Power = 0;
        }
        
        public void takeDamage(int damage)
        {
            Health -= damage;
        }
        
        public void addPower(int power)
        {
            Power += power;
        }
    }
}