using R3;
using UnityEngine;
using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;

        public Observable<GameplayExitParams> Run(DIContainer gameplayDiContainer, GameplayEnterParams gameplayEnterParams)
        {
            // Resolve all gameplay services
            GameplayInstaller.Resolve(gameplayDiContainer, gameplayEnterParams);
            
            // Register all View-Model for gameplay
            var gameplayUIViewModelsContainer = new DIContainer(gameplayDiContainer);
            GameplayViewModelsRegistrations.Register(gameplayUIViewModelsContainer);
                
            // Create UI
            var instance = Instantiate(sceneUIRootPrefab);

            // Get and Attach
            var uiViewRoot = gameplayDiContainer.Resolve<UIViewRoot>();
            uiViewRoot.AttachSceneUI(instance.gameObject);

            // Bind subjext
            var exitSceneSignalSubj = new Subject<Unit>();
            instance.Bind(exitSceneSignalSubj);

            // Created params
            var mainMenuEnterParams = new MainMenuEnterParams("RimuruDev");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            Debug.Log($"Gameplay scene loaded: {gameplayEnterParams}");

            return exitToMainMenuSceneSignal;
        }
    }
}