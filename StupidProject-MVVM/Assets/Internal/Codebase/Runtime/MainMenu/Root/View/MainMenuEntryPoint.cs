using System;
using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Infrastructure.Utilities;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root;
using R3;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder sceneRootUIPrefab;

        public Observable<MainMenuExitParams> Run(DIContainer diContainer, MainMenuEnterParams mainMenuEnterParams)
        {
            // Register all
            MainMenuInstaller.Resolve(diContainer, mainMenuEnterParams);
            
            // Create UI
            var instance = Instantiate(sceneRootUIPrefab);

            // Get and Attach
            var uiViewRoot = diContainer.Resolve<UIViewRoot>();
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