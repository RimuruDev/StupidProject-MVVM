using System;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy buildingEntity;
        private readonly BuildingsService buildingsService;

        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            BuildingEntityId = buildingEntity.Id;

            this.buildingsService = buildingsService;
            this.buildingEntity = buildingEntity;

            Position = buildingEntity.Position;
        }
    }
}