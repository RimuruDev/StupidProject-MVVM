using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Utilities
{
    public static class Helper
    {
        public static T CreateNewGameObject<T>(string name = null, bool autoNaming = true) where T : MonoBehaviour
        {
            GameObject newGameObject;

            if (autoNaming)
            {
                newGameObject = new GameObject($"[ {typeof(T)} ]");
            }
            else
            {
                newGameObject = name == null ? new GameObject($"[ {typeof(T)} ]") : new GameObject(name);
            }

            var attackedComponent = newGameObject.AddComponent<T>();

            return attackedComponent;
        }
    }
}