using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        public readonly BuildingEntityProxy buildingEntity;
        private readonly BuildingsService buildingsService;

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            this.buildingsService = buildingsService;
            this.buildingEntity = buildingEntity;
        }
    }
}