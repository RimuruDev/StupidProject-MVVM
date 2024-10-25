using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Commands
{
    /// <summary>
    /// Спецификация или команда, для постройки строения.
    /// </summary>
    public class CmdPlaceBuilding : ICommand
    {
        public readonly string BuildingTypeId;
        public readonly Vector3Int Position;

        public CmdPlaceBuilding(string buildingTypeId, Vector3Int position)
        {
            BuildingTypeId = buildingTypeId;
            Position = position;
        }
    }
}