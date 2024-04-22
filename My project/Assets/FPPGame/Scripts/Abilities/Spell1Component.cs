using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FPPGame.Abilities
{
    public class Spell1Component : MonoBehaviour
    {
        public Rigidbody _rigidbody;
        public float force = 10.0f;       
        public int DisaperAfterSeconds = 5;

        private void OnEnable()
        {
            _rigidbody.AddForce(transform.forward * force, ForceMode.VelocityChange);       
            Destroy(gameObject, DisaperAfterSeconds);
        }
    }
}