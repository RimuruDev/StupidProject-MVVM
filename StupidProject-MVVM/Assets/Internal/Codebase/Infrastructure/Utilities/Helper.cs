using UnityEngine;
using System.Runtime.CompilerServices;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Utilities
{
    public static class Helper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateNewGameObject<T>(string name = null, bool autoNaming = true, bool dontDestroyOnLoad = false) where T : MonoBehaviour
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

            if (dontDestroyOnLoad)
            {
                Object.DontDestroyOnLoad(newGameObject);
            }
            
            return attackedComponent;
        }
    }
}