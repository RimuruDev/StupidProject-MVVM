using System;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings;
using ObservableCollections;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    /// <summary>
    /// GameplayEntryPoint -> World -> Model
    /// </summary>
    public class WorldGameplayRootViewModel : IDisposable
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;
        private readonly BuildingsService buildingsService;

        public WorldGameplayRootViewModel(BuildingsService buildingsService)
        {
            this.buildingsService = buildingsService;

            AllBuildings = buildingsService.AllBuildings;
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}