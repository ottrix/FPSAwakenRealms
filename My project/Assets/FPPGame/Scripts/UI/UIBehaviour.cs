using TMPro;
using UnityEngine;

namespace FPPGame
{
    public class UIBehaviour : MonoBehaviour
    {
        public TextMeshProUGUI powerAmountText;
        public TextMeshProUGUI ableToCastSpell;

        private void OnEnable()
        {
            EventsManager.PowerChanged += PowerChanged;
            
        }
        
        private void OnDisable()
        {
            EventsManager.PowerChanged -= PowerChanged;
        }
        
        private void PowerChanged()
        {
            powerAmountText.text = GameManager.MainCharacter.Power.ToString();
            
            if (GameManager.MainCharacter.Power >= 10)
            {
                ableToCastSpell.text = "You can cast the spell! Click F";
            }
            else
            {
                ableToCastSpell.text = "You need 10 power to cast a spell!";
            }
        }
    }
}