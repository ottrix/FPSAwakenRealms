using UnityEditor;
using UnityEngine;

namespace FPPGame
    {
        public class GameManager : MonoBehaviour
        {
            private static GameManager _instance;
            private static bool _isGameStarted;
            public static MainCharacter MainCharacter => _instance != null ? _instance._mainCharacterPrefab : null;
            public static ShardSpawner ShardSpawner => _instance != null ? _instance._shardSpawnerPrefab : null;
            public static EnemySpawner EnemySpawner => _instance != null ? _instance._enemySpawnerPrefab : null;
            public static PoofSpawner PoofSpawner => _instance != null ? _instance._poofSpawnerPrefab : null;
            
            public static MainConfig MainConfig;


            private readonly EnemySpawner _enemySpawnerPrefab = new EnemySpawner();
            private readonly MainCharacter _mainCharacterPrefab = new MainCharacter();
            private readonly ShardSpawner _shardSpawnerPrefab = new ShardSpawner();
            private readonly PoofSpawner _poofSpawnerPrefab = new PoofSpawner();

            public void Awake()
            {
                if (_instance == null)
                {
                    _instance = this;
                }

                MainConfig =
                    AssetDatabase.LoadAssetAtPath<MainConfig>("Assets/FPPGame/ScriptableObjects/MainConfig.asset");
            }

            [RuntimeInitializeOnLoadMethod]
            private static void InitializeOnAppStart()
            {
                if (_instance != null)
                {
                    return;
                }

                var go = new GameObject("GameManager");
                go.transform.SetAsFirstSibling();
                go.AddComponent<GameManager>();
            }

            public static bool IsGameStarted
            {
                get => _isGameStarted;
                set
                {
                    if (value == _isGameStarted)
                    {
                        return;
                    }

                    _isGameStarted = value;
                    if (_isGameStarted)
                    {
                        EventsManager.OnGameStarted?.Invoke();
                        MainCharacter.SetupMainCharacter(MainConfig.MainCharacterConfig.MaxHealth,
                            MainConfig.MainCharacterConfig.Damage,
                            MainConfig.MainCharacterConfig.PowerAmountOnTheBeginning);
                    }
                }
            }

            public static void StartRound()
            {
                EventsManager.OnWaveStarted?.Invoke();
                
            }
        


    }
}