using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;

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
            return default;
        }
    }
}