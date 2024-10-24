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

        public GameStateProxy(GameState gameState)
        {
            gameState.Buildings.ForEach(buildingOrigin => Buildings.Add(new BuildingEntityProxy(buildingOrigin)));

            Buildings.ObserveAdd().Subscribe(collectionAddEvent =>
            {
                var addedBuildingEntity = collectionAddEvent.Value;

                gameState.Buildings.Add(new BuildingEntity
                {
                    Id = addedBuildingEntity.Id,
                    TypeId = addedBuildingEntity.TypeId,
                    Position = addedBuildingEntity.Position.Value,
                    Level = addedBuildingEntity.Level.Value
                });
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity = gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removedBuildingEntity);
            });
        }

        public void Dispose()
        {
            DisposeLogger.Log(this);
            
            Buildings.ObserveAdd().Subscribe().Dispose();
            Buildings.ObserveRemove().Subscribe().Dispose();
            Buildings.Clear();
        }
    }
}