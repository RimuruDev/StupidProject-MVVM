using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using AbyssMoth.Internal.Codebase.Infrastructure.AssetManagement;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Boot
{
    public sealed class Bootstrapper
    {
        private const bool LoggerEnable = true;
        private const int TargetFrameRate = 60;
        private const int SleepTimeout = UnityEngine.SleepTimeout.NeverSleep;

        private static Bootstrapper selfInstance;
        private readonly UIViewRoot uiRoot;
        private readonly CoroutineProvider coroutineProvider;

        private readonly WaitForSeconds cooldownTwoSeconds = new(seconds: 2f);

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
            Application.targetFrameRate = TargetFrameRate;
            Screen.sleepTimeout = SleepTimeout;
        }

        private void StartGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == SceneName.Gameplay)
            {
                coroutineProvider.StartCoroutine(routine: LoadAndStartGameplay());
                return;
            }

            if (sceneName != SceneName.Boot)
                return;
#endif

            coroutineProvider.StartCoroutine(routine: LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            uiRoot.ShowLoadingScreen();
            {
                yield return LoadScene(SceneName.Boot);
                yield return LoadScene(SceneName.Gameplay);

                yield return cooldownTwoSeconds;

                var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>(FindObjectsInactive.Include);
                sceneEntryPoint.Run();
            }
            uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            Log($"LoadSceneAsync({sceneName});", coroutineProvider.gameObject);

            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private static void Log(string message, Object context = null)
        {
            if (!LoggerEnable)
                return;

            Debug.Log(message, context);
        }
    }
}