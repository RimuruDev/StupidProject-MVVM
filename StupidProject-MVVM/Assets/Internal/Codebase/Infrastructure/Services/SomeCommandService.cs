using System;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using ObservableCollections;
using UnityEngine;
using R3;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Services
{
    public class SomeCommandService : IDisposable
    {
        private readonly IDisposable addSubscription;
        private readonly IDisposable removeSubscription;

        public SomeCommandService(IGameStateProvider gameState)
        {
            Debug.Log($"{GetType().Name} has been created!");

            gameState.GameState.Buildings.ForEach(x => Debug.Log($"Building: {x}"));

            addSubscription = gameState.GameState.Buildings.ObserveAdd().Subscribe(e => Debug.Log($"Building: {e.Value}"));
            removeSubscription = gameState.GameState.Buildings.ObserveRemove().Subscribe(e => Debug.Log($"Building: {e.Value}"));
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");

            addSubscription?.Dispose();
            removeSubscription?.Dispose();
        }
    }
}