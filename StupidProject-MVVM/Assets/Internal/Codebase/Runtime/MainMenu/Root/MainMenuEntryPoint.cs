using System;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.View;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        public event Action GoToGameplayButtonClickedRequested;
        
        [SerializeField] private UIMainMenuRootBinder sceneRootUIPrefab;

        public void Run(UIViewRoot uiViewRoot)
        {
            //Debug.Log($"Gameplay scene loaded");
            var instance = Instantiate(sceneRootUIPrefab);
            uiViewRoot.AttachSceneUI(instance.gameObject);

            instance.GoToGameplayButtonClicked += () => { GoToGameplayButtonClickedRequested?.Invoke(); };
        }
    }
}