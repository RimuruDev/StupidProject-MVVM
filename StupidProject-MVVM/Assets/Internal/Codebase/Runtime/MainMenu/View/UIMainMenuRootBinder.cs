using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.View
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;

        public void HandleGoToGameplayButtonClicked() => 
            GoToGameplayButtonClicked?.Invoke();
    }
}