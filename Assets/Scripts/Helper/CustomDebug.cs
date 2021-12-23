using UnityEngine;
using Object = UnityEngine.Object;

namespace DroneBase
{
    public static class CustomDebug
    {
        public static void Log(object value)
        {
            if (Debug.isDebugBuild)
                Debug.Log(value, null);
        }

        public static void LogWarning(object value)
        {
            if (Debug.isDebugBuild)
                Debug.LogWarning(value, null);
        }

        public static void LogError(object value)
        {
            if (Debug.isDebugBuild)
                Debug.LogError(value, null);
        }

        public static void Log(object value, Object unityObject)
        {
            if (Debug.isDebugBuild)
                Debug.Log(value, unityObject);
        }
    }
}