using System;
using System.Collections;
using UnityEngine;

namespace FPPGame
{
    public class Poof : MonoBehaviour
    {
        public ParticleSystem ParticleSystem;

        private void OnEnable()
        {
            Play();
        }
        
        public void Setup(Vector3 position)
        {
            transform.position = position;
            Debug.Log($"{position} after spawn in poof");
        }

        private void Play()
        {
            ParticleSystem.Play();
            
            Invoke(nameof(ReturnToPool), ParticleSystem.main.duration +0.1f);
        }
        
      
        public void ReturnToPool()
        {
            ObjectPoolManager.ReturnObject(this);
        }
    }
}