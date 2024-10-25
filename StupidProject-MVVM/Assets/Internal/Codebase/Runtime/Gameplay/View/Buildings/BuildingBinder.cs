using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.View.Buildings
{
    public class BuildingBinder : MonoBehaviour
    {
        public void Bind(BuildingViewModel buildingViewModel)
        {
            transform.transform.position = buildingViewModel.Position.CurrentValue;
        }
    }
}