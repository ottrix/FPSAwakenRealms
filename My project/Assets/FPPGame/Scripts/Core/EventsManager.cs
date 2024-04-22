using System;

namespace FPPGame
{
    public static class EventsManager
    {
        public static Action OnWaveStarted;
        public static Action WaveEnded;
        public static Action OnGameStarted;
        public static Action OnEnemyDied;
        public static Action OnPlayerDied;
        public static Action PowerChanged;
    }
}