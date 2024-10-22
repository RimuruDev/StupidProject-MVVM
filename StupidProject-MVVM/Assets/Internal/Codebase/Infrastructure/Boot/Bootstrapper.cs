using System.Collections;
using AbyssMoth.Internal.Codebase.Infrastructure.AssetManagement;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Boot
{
    public sealed class Bootstrapper
    {
        private static Bootstrapper selfInstance;
        private readonly CoroutineProvider coroutineProvider;
        private readonly UIViewRoot uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialization()
        {
            SetupSystemSettings();

            selfInstance = new Bootstrapper();
            selfInstance.StartGame();
        }

        private Bootstrapper()
        {
            coroutineProvider = Helper.CreateNewGameObject<CoroutineProvider>(dontDestroyOnLoad: true);

            var prefabUIViewRoot = Resources.Load<UIViewRoot>(AssetPath.UIRoot);
            uiRoot = Helper.InstantiateDontDestroyOnLoad(prefabUIViewRoot);
        }

        private static void SetupSystemSettings()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void StartGame()
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

            coroutineProvider.StartCoroutine(LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            uiRoot.ShowLoadingScreen();
            {
                yield return LoadScene(SceneName.BOOT);
                yield return LoadScene(SceneName.GAMEPLAY);

                yield return new WaitForEndOfFrame();

                var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>(FindObjectsInactive.Include);
                sceneEntryPoint.Run();
            }
            uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            Debug.Log($"LoadSceneAsync({sceneName});", coroutineProvider.gameObject);
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}