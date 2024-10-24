using System;
using System.Linq;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using ObservableCollections;
using UnityEngine;
using R3;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Services
{
    public class SomeCommandService : IDisposable
    {
        private readonly IGameStateProvider gameState;
        private readonly IDisposable addSubscription;
        private readonly IDisposable removeSubscription;

        public SomeCommandService(IGameStateProvider gameState)
        {
            this.gameState = gameState;
            
            Debug.Log($"{GetType().Name} has been created!");

            gameState.GameState.Buildings.ForEach(x => Debug.Log($"Building: {x}"));

            addSubscription = gameState.GameState.Buildings.ObserveAdd().Subscribe(e => Debug.Log($"Building: {e.Value}"));
            removeSubscription = gameState.GameState.Buildings.ObserveRemove().Subscribe(e => Debug.Log($"Building: {e.Value}"));

            AddBuilding("Merunya");
            AddBuilding("Megumin");
            
            RemoveBuilding("Merunya");
            RemoveBuilding("Megumin");
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");

            addSubscription?.Dispose();
            removeSubscription?.Dispose();
        }

        private void AddBuilding(string id)
        {
            var newBuilding = new BuildingEntity
            {
                TypeId = id
            };

            var proxy = new BuildingEntityProxy(newBuilding);
            gameState.GameState.Buildings.Add(proxy);
        }  
        
        private void RemoveBuilding(string id)
        {
            var buildingForRemove =gameState.GameState.Buildings.FirstOrDefault(x => x.TypeId == id);

            if (buildingForRemove != null)
            {
                gameState.GameState.Buildings.Remove(buildingForRemove);
            }
        }
    }
}