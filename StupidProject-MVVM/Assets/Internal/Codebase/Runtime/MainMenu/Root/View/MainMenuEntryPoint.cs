using AbyssMoth.DI;
using R3;
using UnityEngine;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.Installer;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder sceneRootUIPrefab;

        public Observable<MainMenuExitParams> Run(DIContainer mainMenuDiContainer, MainMenuEnterParams mainMenuEnterParams)
        {
            // Register all
            MainMenuInstaller.Resolve(mainMenuDiContainer, mainMenuEnterParams);
            
            // Register all View-Model for gameplay
            var mainMenuUIViewModelsContainer = new DIContainer(mainMenuDiContainer);
            MainMenuViewModelsRegistrations.Register(mainMenuUIViewModelsContainer);
            
            // Test Resolve
            mainMenuUIViewModelsContainer.Resolve<UIMainMenuRootViewModel>();
            
            // Create UI
            var instance = Instantiate(sceneRootUIPrefab);

            // Get and Attach
            var uiViewRoot = mainMenuDiContainer.Resolve<UIViewRoot>();
            uiViewRoot.AttachSceneUI(instance.gameObject);

            // Bind subject
            var exitSceneSubject = new Subject<Unit>();
            instance.Bind(exitSceneSubject);

            // Create params
            var gameplayEnterParams = new GameplayEnterParams(SceneName.Gameplay, "GameplayDatabase", 1);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);

            var exitTiGameplay = exitSceneSubject.Select(_ => mainMenuExitParams);

            Debug.Log($"Gameplay scene loaded: {mainMenuEnterParams?.Result}");

            return exitTiGameplay;
        }
    }
}