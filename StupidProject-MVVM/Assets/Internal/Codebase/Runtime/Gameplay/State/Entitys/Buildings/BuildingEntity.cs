using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings
{
    /// <summary>
    /// Сущность для строений.
    /// </summary>
    [Serializable]
    public class BuildingEntity : Entity
    {
        /// <summary>
        /// Идентификатор строения.
        /// </summary>
        public string TypeId;

        /// <summary>
        /// Позиция строения.
        /// </summary>
        public Vector3Int Position;

        /// <summary>
        /// Уровень строения.
        /// </summary>
        public int Level;
    }
}