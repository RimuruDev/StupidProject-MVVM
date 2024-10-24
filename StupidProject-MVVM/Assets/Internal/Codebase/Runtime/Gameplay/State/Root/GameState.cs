using System;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root
{
    [Serializable]
    public class GameState
    {
        public List<BuildingEntity> Buildings;
        //public GameSettingsState GameSettings;
    }
}