using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Buildings
{
    [Serializable]
    public class BuildingEntity
    {
        public int Id;
        public string TypeId;
        public Vector3Int Position;
        public int Level;

        public override string ToString() =>
            $"Id: {Id} | TypeId: {TypeId} | Position: [{Position}] | Level: {Level}";
    }
}