using UnityEngine;
using System.Collections;
using AbyssMoth.DI;
using UnityEngine.SceneManagement;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using AbyssMoth.Internal.Codebase.Infrastructure.AssetManagement;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View;
using R3;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Boot
{
    public sealed class Bootstrapper
    {
        private const bool LoggerEnable = false;
        private const int TargetFrameRate = 60;
        private const int SleepTimeout = UnityEngine.SleepTimeout.NeverSleep;

        private static Bootstrapper selfInstance;
        private readonly UIViewRoot uiRoot;
        private readonly CoroutineProvider coroutineProvider;
        private readonly DIContainer projectContext = new();
        private DIContainer cachedSceneContainer;

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

            // Game Registrations ===
            projectContext.RegisterInstance(uiRoot);

            var gameStateProvider = new PlayerPrefsGameStateProvider();
            gameStateProvider.LoadSettingsState();
            
            projectContext.RegisterInstance<IGameStateProvider>(gameStateProvider);
        }

        private static void SetupSystemSettings()
        {
            Application.targetFrameRate = TargetFrameRate;
            Screen.sleepTimeout = SleepTimeout;
        }

        private void StartGame()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            
            var testGameplayConfig = new GameplayEnterParams(SceneName.Gameplay, "Mac->Dataset.json",1);
            var testMainMenuConfig = new MainMenuEnterParams(SceneName.MainMenu);
            
#if UNITY_EDITOR
            if (sceneName == SceneName.Gameplay)
            {
                coroutineProvider.StartCoroutine(routine: LoadAndStartGameplay(testGameplayConfig));
                return;
            }

            if (sceneName == SceneName.MainMenu)
            {
                coroutineProvider.StartCoroutine(routine: LoadAndStartMainMenu(testMainMenuConfig));
                return;
            }

            if (sceneName != SceneName.Boot)
                return;
#endif

            coroutineProvider.StartCoroutine(routine: LoadAndStartMainMenu(testMainMenuConfig));
        }

        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams = null)
        {
            uiRoot.ShowLoadingScreen();
            cachedSceneContainer?.Dispose();
            {
                yield return LoadScene(SceneName.Boot);
                yield return LoadScene(SceneName.Gameplay);

                yield return cooldownTwoSeconds;

                var isGameStateLoaded = false;
                var loadGameStateSubscription = projectContext
                    .Resolve<IGameStateProvider>()
                    .LoadGameState()
                    .Subscribe(_ => isGameStateLoaded = true);

                yield return new WaitUntil(() => isGameStateLoaded);

                // На всякий случай лучше я отпишусь туть :3 Хотя после перехода на новую сцену полюбас GC все подчистит.
                // Лучше перебдеть чем недобдеть. 
                loadGameStateSubscription.Dispose();

                var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>(FindObjectsInactive.Include);

                var gameplaySceneContainer = cachedSceneContainer = new DIContainer(projectContext);

                sceneEntryPoint
                    .Run(gameplaySceneContainer, enterParams)
                    .Subscribe(gameplayExitParams =>
                    {
                        coroutineProvider.StartCoroutine(
                            routine: LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
                    });
            }
            uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null)
        {
            uiRoot.ShowLoadingScreen();
            cachedSceneContainer?.Dispose();
            {
                yield return LoadScene(SceneName.Boot);
                yield return LoadScene(SceneName.MainMenu);

                yield return cooldownTwoSeconds;

                var sceneEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>(FindObjectsInactive.Include);

                var mainMenuSceneContainer = cachedSceneContainer = new DIContainer(projectContext);

                sceneEntryPoint
                    .Run(mainMenuSceneContainer, enterParams)
                    .Subscribe(mainMenuExitParams =>
                    {
                        var sceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;

                        switch (sceneName)
                        {
                            case SceneName.Gameplay:
                                var param = mainMenuExitParams.TargetSceneEnterParams.As<GameplayEnterParams>();
                                coroutineProvider.StartCoroutine(routine: LoadAndStartGameplay(param));
                                break;
                            case SceneName.MainMenu:
                                coroutineProvider.StartCoroutine(routine: LoadAndStartMainMenu());
                                break;
                        }
                    });
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

#pragma warning disable CS0162 // Unreachable code detected
            Debug.Log(message, context);
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}