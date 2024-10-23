using System;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings
{
    public class BuildingEntityProxy : IDisposable
    {
        private const int FirstElement = 1;

        public int Id { get; }
        public string TypeId { get; }

        public ReactiveProperty<Vector3Int> Position { get; }
        public ReactiveProperty<int> Level { get; }

        public BuildingEntityProxy(BuildingEntity buildingEntity)
        {
            Id = buildingEntity.Id;
            TypeId = buildingEntity.TypeId;

            Position = new ReactiveProperty<Vector3Int>(buildingEntity.Position);
            Level = new ReactiveProperty<int>(buildingEntity.Level);

            Position.Skip(FirstElement).Subscribe(value => buildingEntity.Position = value);
            Level.Skip(FirstElement).Subscribe(value => buildingEntity.Level = value);
        }

        public void Dispose()
        {
            Position?.Dispose();
            Level?.Dispose();
        }
    }
}