using System;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Commands;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings;
using ObservableCollections;
using UnityEngine;
using R3;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services
{
    //
    // NOTE: На вход Model и CommandHandler то-есть buildings и cmdProcessor, а на выход ViewModel
    //
    /// <summary>
    /// Сервис для построек:
    /// Прослойка между View, Model, CommandHandler
    /// </summary>
    public class BuildingsService : IDisposable
    {
        private readonly ICommandProcessor cmd;
        private readonly ObservableList<BuildingViewModel> allBuildings = new();
        private readonly Dictionary<int, BuildingViewModel> buildingsMap = new();

        private readonly IDisposable addSubscription;
        private readonly IDisposable removeSubscription;

        private IObservableCollection<BuildingViewModel> AllBuildings => allBuildings;

        /// <param name="buildings">Model - строений.</param>
        /// <param name="cmdProcessor">CommandHandler - изменения стейта.</param>
        public BuildingsService(IObservableCollection<BuildingEntityProxy> buildings, ICommandProcessor cmdProcessor)
        {
            cmd = cmdProcessor;

            foreach (var buildingEntity in buildings)
            {
                CreateBuildingViewModel(buildingEntity);
            }

            addSubscription = buildings.ObserveAdd().Subscribe(e =>
            {
                CreateBuildingViewModel(e.Value);
            });

            removeSubscription = buildings.ObserveRemove().Subscribe(e =>
            {
                RemoveBuildingViewModel(e.Value);
            });
        }

        public bool PlaceBuilding(string buildingTypeId, Vector3Int position)
        {
            var placeCommand = new CmdPlaceBuilding(buildingTypeId, position);
            var result = cmd.Process(placeCommand);

            return result;
        }

        public bool MoveBuilding(int buildingEntityId, Vector3Int newPosition)
        {
            return true;
        }

        public bool DeleteBuilding(int buildingEntityId)
        {
            if (buildingsMap.TryGetValue(buildingEntityId, out var building))
            {
                allBuildings.Remove(building);

                buildingsMap.Remove(buildingEntityId);

                return true;
            }

            return false;
        }

        public void Dispose()
        {
            addSubscription?.Dispose();
            removeSubscription?.Dispose();
        }

        private void CreateBuildingViewModel(BuildingEntityProxy buildingEntity)
        {
            var buildingViewModel = new BuildingViewModel(buildingEntity, this);

            allBuildings.Add(buildingViewModel);

            buildingsMap[buildingEntity.Id] = buildingViewModel;
        }

        private void RemoveBuildingViewModel(BuildingEntityProxy buildingEntity)
        {
            var id = buildingEntity.Id;

            if (buildingsMap.TryGetValue(id, out var buildingViewModel))
            {
                allBuildings.Remove(buildingViewModel);

                buildingsMap.Remove(id);
            }
        }
    }
}