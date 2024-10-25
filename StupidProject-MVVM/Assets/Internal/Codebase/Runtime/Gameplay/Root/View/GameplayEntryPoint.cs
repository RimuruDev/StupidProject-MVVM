using AbyssMoth.DI;
using R3;
using UnityEngine;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;
        [SerializeField] private WorldGameplayRootBinder worldGameplayRootBinder;

        public Observable<GameplayExitParams> Run(DIContainer gameplayDiContainer, GameplayEnterParams gameplayEnterParams)
        {
            // Resolve all gameplay services
            GameplayInstaller.Resolve(gameplayDiContainer, gameplayEnterParams);

            // Register all View-Model for gameplay
            var gameplayUIViewModelsContainer = new DIContainer(gameplayDiContainer);
            GameplayViewModelsRegistrations.Register(gameplayUIViewModelsContainer);
            
            var buildingService = gameplayDiContainer.Resolve<BuildingsService>();
            buildingService.PlaceBuilding("_ShadowGarage", new Vector3Int(45, 2, 52));
            buildingService.PlaceBuilding("_Gas", new Vector3Int(3, 1, 5));
            buildingService.PlaceBuilding("_Kira", new Vector3Int(5, 4, 14));

            gameplayUIViewModelsContainer.Resolve<UIGameplayRootViewModel>();
            var worldGameplayRootViewModel = gameplayUIViewModelsContainer.Resolve<WorldGameplayRootViewModel>();

            worldGameplayRootBinder.Bind(worldGameplayRootViewModel);

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