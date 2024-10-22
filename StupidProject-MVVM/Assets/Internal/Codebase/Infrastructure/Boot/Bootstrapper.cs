using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Boot
{
    public sealed class Bootstrapper
    {
        private static Bootstrapper selfInstance;
        private CoroutineProvider coroutineProvider;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialization()
        {
            SetupSystemSettings();

            selfInstance = new Bootstrapper();
            selfInstance.StartGame();
        }

        private Bootstrapper()
        {
            coroutineProvider = Helper.CreateNewGameObject<CoroutineProvider>();
        }

        private static void SetupSystemSettings()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void StartGame()
        {
        }
    }
}