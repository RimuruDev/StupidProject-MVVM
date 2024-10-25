using System;
using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root
{
    /// <summary>
    /// Gameplay данные текущего состояния игры.
    /// </summary>
    [Serializable]
    public class GameState
    {
        /// <summary>
        /// Последний актуальный Id.
        /// Глобальный счетчик сущностей.
        /// При создании сущностей, счетчик будет инкрементироваться для создания уникального id.
        /// </summary>
        public int GlobalEntityId;

        /// <summary>
        /// Список сущностей строений.
        /// </summary>
        public List<BuildingEntity> Buildings;
    }
}