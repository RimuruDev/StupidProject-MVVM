using System;
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.View;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMainMenuButtonClicked;

        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;

        public void Run(UIViewRoot uiViewRoot)
        {
            Debug.Log($"Gameplay scene loaded");
            var instance = Instantiate(sceneUIRootPrefab);
            uiViewRoot.AttachSceneUI(instance.gameObject);

            instance.GoToMainMenuButtonClicked += () => { GoToMainMenuButtonClicked?.Invoke(); };
        }
    }
}