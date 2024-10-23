using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public class UIMainMenuRootViewModel : IDisposable
    {
        public UIMainMenuRootViewModel()
        {
            Debug.Log($"{GetType().Name} has been created!");
        }
        
        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}