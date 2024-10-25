using R3;
using System;
using System.Linq;
using ObservableCollections;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root
{
    public class GameStateProxy : IDisposable
    {
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();

        private readonly GameState gameState;
        private readonly IDisposable addSubscription;
        private readonly IDisposable removeSubscription;

        public GameStateProxy(GameState gameState)
        {
            this.gameState = gameState;
            
            this.gameState.Buildings.ForEach(buildingOrigin => Buildings.Add(new BuildingEntityProxy(buildingOrigin)));

            addSubscription = Buildings.ObserveAdd().Subscribe(collectionAddEvent =>
            {
                var addedBuildingEntity = collectionAddEvent.Value;

                this.gameState.Buildings.Add(new BuildingEntity
                {
                    Id = addedBuildingEntity.Id,
                    TypeId = addedBuildingEntity.TypeId,
                    Position = addedBuildingEntity.Position.Value,
                    Level = addedBuildingEntity.Level.Value
                });
            });

            removeSubscription = Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity = this.gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                this. gameState.Buildings.Remove(removedBuildingEntity);
            });
        }

        /// <summary>
        /// Получить уникальный идентификатор для сущности.
        /// </summary>
        /// <returns></returns>
        public int GetEntityId()
        {
            return gameState.GlobalEntityId++;
        }

        public void Dispose()
        {
            DisposeLogger.Log(this);

            addSubscription?.Dispose();
            removeSubscription?.Dispose();

            Buildings.Clear();
        }
    }
}