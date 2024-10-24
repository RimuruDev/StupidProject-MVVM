using System;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services
{
    public class GameplayStatisticsService : IDisposable
    {
        private readonly GameStateProxy gameState;
        private readonly SomeCommandService someCommandService;

        public GameplayStatisticsService(GameStateProxy gameState, SomeCommandService someCommandService)
        {
            this.gameState = gameState;
            this.someCommandService = someCommandService;

            gameState.Buildings.ForEach(Debug.Log);

            Debug.Log($"{GetType().Name} has been created!");
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}