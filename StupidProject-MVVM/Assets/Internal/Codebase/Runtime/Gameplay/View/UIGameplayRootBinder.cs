using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.View
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        public event Action GoToMainMenuButtonClicked;

        public void HandleGoToMoinMenuButtonClicked() => 
            GoToMainMenuButtonClicked?.Invoke();
    }
}