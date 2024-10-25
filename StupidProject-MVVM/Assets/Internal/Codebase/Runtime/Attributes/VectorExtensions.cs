using R3;
using UnityEngine;

namespace AbyssMoth
{
    public static class VectorExtensions
    {
        public static Vector3 ToVector3(this ReadOnlyReactiveProperty<Vector3Int> readOnlyReactivePosition)
        {
            var currentValue = readOnlyReactivePosition.CurrentValue;

            return new Vector3(currentValue.x, currentValue.y, currentValue.z);
        }

        public static Vector3 ToVector3(this Vector3Int position)
        {
            return new Vector3(position.x, position.y, position.z);
        }
    }
}