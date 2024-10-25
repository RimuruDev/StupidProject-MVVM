using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    /// <summary>
    /// GameplayEntryPoint -> UI -> Models
    /// </summary>
    public class UIGameplayRootViewModel : IDisposable
    {
        public UIGameplayRootViewModel()
        {
            Debug.Log($"{GetType().Name} has been created!");
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}