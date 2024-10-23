using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel : IDisposable
    {
        public WorldGameplayRootViewModel()
        {
            Debug.Log($"{GetType().Name} has been created!");
        }
        
        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}