using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwayBehaviour : MonoBehaviour
    {
        [SerializeField] private int _smoothnessOfSwing;
        [SerializeField] private int _movementFactor;
        
        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _smoothnessOfSwing;
            float mouseY = Input.GetAxis("Mouse Y") * _smoothnessOfSwing;

            Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
            Quaternion rotationY = Quaternion.AngleAxis(-mouseX, Vector3.up);
            
            Quaternion weaponRotation = rotationX * rotationY;

            transform.localRotation = Quaternion.Slerp(transform.localRotation, weaponRotation, Time.deltaTime * _movementFactor);
        }
    }
}