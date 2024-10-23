using AbyssMoth.Internal.Codebase.DI.Container;
using R3;
using UnityEngine;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;

        public Observable<GameplayExitParams> Run(DIContainer diContainer, GameplayEnterParams gameplayEnterParams)
        {
            // Create UI
            var instance = Instantiate(sceneUIRootPrefab);

            // Get and Attach
            var uiViewRoot = diContainer.Resolve<UIViewRoot>();
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