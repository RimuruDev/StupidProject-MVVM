using AbyssMoth.DI;
using R3;
using UnityEngine;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Commands;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;

        public Observable<GameplayExitParams> Run(DIContainer gameplayDiContainer,
            GameplayEnterParams gameplayEnterParams)
        {
            // Resolve all gameplay services
            GameplayInstaller.Resolve(gameplayDiContainer, gameplayEnterParams);

            // Register all View-Model for gameplay
            var gameplayUIViewModelsContainer = new DIContainer(gameplayDiContainer);
            GameplayViewModelsRegistrations.Register(gameplayUIViewModelsContainer);

            // start->Test
            //
            //

            var gameStateProvider = gameplayDiContainer.Resolve<IGameStateProvider>();
            var gameState = gameplayDiContainer.Resolve<IGameStateProvider>().GameState;

            var cmd = new CommandProcessor(gameStateProvider);
            var placeBuildingCommandHandler = new CmdPlaceBuildingHandler(gameState);
            cmd.RegisterHandler(placeBuildingCommandHandler);

            var placeBuildingCommand = new CmdPlaceBuilding("ExploitDev", new Vector3Int(666, 666, 666));
            var r = cmd.Process(placeBuildingCommand);
            Debug.Log($"r: {r}");
            //
            //
            // end->Test

            // Test Resolve
            gameplayUIViewModelsContainer.Resolve<UIGameplayRootViewModel>();
            gameplayUIViewModelsContainer.Resolve<WorldGameplayRootViewModel>();

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