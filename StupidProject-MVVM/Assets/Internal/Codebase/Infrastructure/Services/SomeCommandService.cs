using System;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Services
{
    public class SomeCommandService : IDisposable
    {
        private readonly GameStateProxy gameState;
        
        public SomeCommandService(IGameStateProvider gameState)
        {
            Debug.Log($"{GetType().Name} has been created!");
            
            gameState.GameState.Buildings.ForEach(x => Debug.Log($"Building: {x}"));
        }
        
        public void Dispose() => Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
    }
}