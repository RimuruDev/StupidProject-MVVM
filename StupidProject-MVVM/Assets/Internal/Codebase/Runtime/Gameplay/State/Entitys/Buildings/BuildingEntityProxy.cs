using System;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings
{
    /// <summary>
    /// Proxy для сущностей строений.
    /// </summary>
    public class BuildingEntityProxy : IDisposable
    {
        private const int SkipFirstInvoke = 1;

        public int Id { get; }
        public string TypeId { get; }

        /// <summary>
        /// Ссылка на оригинальный экземпляр данных не обернутый прокси.
        /// </summary>
        public BuildingEntity Origin { get; }

        public ReactiveProperty<Vector3Int> Position { get; }
        public ReactiveProperty<int> Level { get; }

        private readonly IDisposable levelSubscription;
        private readonly IDisposable positionSubscription;

        public BuildingEntityProxy(BuildingEntity buildingEntity)
        {
            Origin = buildingEntity;
            
            Id = buildingEntity.Id;
            TypeId = buildingEntity.TypeId;

            Position = new ReactiveProperty<Vector3Int>(buildingEntity.Position);
            Level = new ReactiveProperty<int>(buildingEntity.Level);

            positionSubscription = Position.Skip(SkipFirstInvoke).Subscribe(value => buildingEntity.Position = value);
            levelSubscription = Level.Skip(SkipFirstInvoke).Subscribe(value => buildingEntity.Level = value);
        }

        public void Dispose()
        {
            DisposeLogger.Log(this);

            positionSubscription?.Dispose();
            levelSubscription?.Dispose();
        }

        public override string ToString() =>
            $"Id: {Id} | TypeId: {TypeId} | Position: [{Position.Value}] | Level: {Level}";
    }
}