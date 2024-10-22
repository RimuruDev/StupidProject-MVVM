using System.Collections;
using AbyssMoth.Internal.Codebase.Infrastructure.AssetManagement;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            HandleEditor();
            HandleRuntime();
        }

        private void HandleEditor()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == SceneName.GAMEPLAY)
            {
                coroutineProvider.StartCoroutine(LoadAndStartGameplay());
                return;
            }

            if (sceneName != SceneName.BOOT)
                return;
#endif
        }

        private void HandleRuntime()
        {
            coroutineProvider.StartCoroutine(LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            uiRoot.ShowLoadingScreen();
            {
                yield return LoadScene(SceneName.BOOT);
            }
            uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}