using R3;
using System;
using UnityEngine;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders
{
    /// <summary>
    /// Провайдер сохранения игры в UnityEngine.PlayerPrefs
    /// </summary>
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);

        public GameStateProxy GameState { get; private set; }

        private GameState gameStateOrigin;

        public Observable<bool> SaveGameState()
        {
            try
            {
                var json = JsonUtility.ToJson(gameStateOrigin, true);
                PlayerPrefs.SetString(GAME_STATE_KEY, json);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                Debug.Log($"Fatal Error: Attempt save game state.");

                return Observable.Return(false);
            }

            return Observable.Return(true);
        }

        public Observable<GameStateProxy> LoadGameState()
        {
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                GameState = CreateGameStateFromSettings();

                Debug.Log($"Game state created from settings: {JsonUtility.ToJson(gameStateOrigin, true)}");

                SaveGameState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                gameStateOrigin = JsonUtility.FromJson<GameState>(json);
                GameState = new GameStateProxy(gameStateOrigin);

                Debug.Log($"Game state loaded: {json}");
            }

            return Observable.Return(GameState);
        }

        public Observable<bool> ResetGameState()
        {
            try
            {
                GameState = CreateGameStateFromSettings();

                Debug.Log($"Game state reset!!!");

                SaveGameState();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);

                return Observable.Return(false);
            }

            return Observable.Return(true);
        }

        private GameStateProxy CreateGameStateFromSettings()
        {
            gameStateOrigin = new GameState
            {
                Buildings = new List<BuildingEntity>
                {
                    new()
                    {
                        Id = 666,
                        TypeId = "Rimurmuru",
                        Level = 999,
                        Position = new Vector3Int
                        {
                            x = 12,
                            y = 812,
                            z = 213,
                        }
                    },
                    new()
                    {
                        Id = 2134,
                        TypeId = "Kail",
                        Level = 14,
                        Position = new Vector3Int
                        {
                            x = 53,
                            y = 21,
                            z = 2,
                        }
                    },
                    new()
                    {
                        Id = 7431,
                        TypeId = "ExploitDev",
                        Level = 1000,
                        Position = new Vector3Int
                        {
                            x = 23,
                            y = 312,
                            z = 412,
                        }
                    },
                },
            };

            return new GameStateProxy(gameStateOrigin);
        }
    }
}