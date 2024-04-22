using System;
using UnityEngine;

namespace FPPGame
{
    public class UIWaveManager : MonoBehaviour
    {
        public GameObject _textAreYouReady;

        private void OnEnable()
        {
            EventsManager.WaveEnded += WaveEnded;
        }
        
        private void OnDisable()
        {
            EventsManager.WaveEnded -= WaveEnded;
        }
        
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.R) && GameManager.EnemySpawner.IsWaveActive == false)
            {
                OnClickStartWave();
            }
        }
        private void WaveEnded()
        {
            GameManager.EnemySpawner.IsWaveActive = false;
            GameManager.EnemySpawner.CurrentWave++;
            GameManager.EnemySpawner.EnemiesSpawned = 0;
            GameManager.EnemySpawner.EnemiesKilled = 0;
            _textAreYouReady.SetActive(true);
        }
        
        public void OnClickStartWave()
        {
            _textAreYouReady.SetActive(false);
            EventsManager.OnWaveStarted?.Invoke();
        }
    }
}