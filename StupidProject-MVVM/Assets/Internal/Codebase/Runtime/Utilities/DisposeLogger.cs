using UnityEngine;

using UnityEngineObject = UnityEngine.Object;
using SystemObject = System.Object;

namespace AbyssMoth
{
    public static class DisposeLogger
    {
        public static bool EnabledLogger = true;

        public static void Log(UnityEngineObject type)
        {
            InternalLog(type.GetType().Name);
        }

        public static void Log(SystemObject type)
        {
            InternalLog(type.GetType().Name);
        }

        private static void InternalLog(string message)
        {
            if (EnabledLogger == false)
                return;

            Debug.Log($"<color=green>{message} disposed!</color>");
        }
    }
}