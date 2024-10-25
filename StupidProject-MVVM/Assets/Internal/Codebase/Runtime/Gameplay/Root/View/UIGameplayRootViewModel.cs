using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class UIGameplayRootViewModel : IDisposable
    {

        public UIGameplayRootViewModel( )
        {
            
            Debug.Log($"{GetType().Name} has been created!");
        }
        
        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}