using AbyssMoth.Internal.Codebase.Infrastructure.AssetManagement;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Boot
{
    public sealed class Bootstrapper
    {
        private static Bootstrapper selfInstance;
        private CoroutineProvider coroutineProvider;
        public UIViewRoot uiRoot;

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

            var prefabUIViewRoot = Resources.Load<UIViewRoot>(AssetPath.UIRoot);
            Helper.InstantiateDontDestroyOnLoad(prefabUIViewRoot);
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