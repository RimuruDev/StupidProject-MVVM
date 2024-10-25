using System;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Commands
{
    /// <summary>
    /// Обработчик команды, для постройки строения CmdPlaceBuilding.
    /// Он на 100% знает как именно строить их (:3)
    /// </summary>
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameStateProxy)
        {
            gameState = gameStateProxy;
        }

        public bool Handle(CmdPlaceBuilding command)
        {
            try
            {
                var entityId = gameState.GetEntityId();
                var newBuildingEntity = new BuildingEntity
                {
                    Id = entityId,
                    TypeId = command.BuildingTypeId,
                    Position = command.Position,
                    Level = 1,
                };

                var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
                gameState.Buildings.Add(newBuildingEntityProxy);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                return false;
            }

            // Пока что по умолчанию true.
            // Но потом если не хватает рeсурсов или уровня, то false.
            // В общем валидация потом будет тут.
            return true;
        }
    }
}