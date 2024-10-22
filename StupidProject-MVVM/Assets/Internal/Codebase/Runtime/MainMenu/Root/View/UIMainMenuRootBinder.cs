using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;

        public void HandleGoToGameplayButtonClicked() => 
            GoToGameplayButtonClicked?.Invoke();
    }
}