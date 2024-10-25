using System;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings;
using ObservableCollections;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    /// <summary>
    /// Байндер мира)
    /// </summary>
    public class WorldGameplayRootBinder : MonoBehaviour
    {
        [SerializeField] private BuildingBinder buildingBinderPrefab;

        private readonly Dictionary<int, BuildingBinder> createdBuildingsMap = new();
        private readonly CompositeDisposable disposables = new();

        private WorldGameplayRootViewModel rootViewModel;

        public void Bind(WorldGameplayRootViewModel gameplayRootViewModel)
        {
            rootViewModel = gameplayRootViewModel;

            foreach (var buildingViewModel in rootViewModel.AllBuildings)
            {
                CreateBuilding(buildingViewModel);
            }
            
            disposables.Add(rootViewModel.AllBuildings.ObserveAdd().Subscribe(e =>
            {
                // Как только появятся данные о новом строении, она авто создастся!
                CreateBuilding(e.Value);
            }));
            
            disposables.Add(rootViewModel.AllBuildings.ObserveRemove().Subscribe(e =>
            {
                // Как только появятся данные о новом строении, она авто удалится!
                DestroyBuilding(e.Value);
            }));
        }

        private void OnDestroy()
        {
            DisposeLogger.Log(this);
            disposables?.Dispose();
        }

        private void CreateBuilding(BuildingViewModel buildingViewModel)
        {
            var building = Instantiate(buildingBinderPrefab);
            building.Bind(buildingViewModel);
            createdBuildingsMap[buildingViewModel.BuildingEntityId] = building;
        }

        private void DestroyBuilding(BuildingViewModel buildingViewModel)
        {
            if (createdBuildingsMap.TryGetValue(buildingViewModel.BuildingEntityId, out var viewModelBinder))
            {
                Destroy(viewModelBinder.gameObject);
                createdBuildingsMap.Remove(buildingViewModel.BuildingEntityId);
            }
        }
    }
}