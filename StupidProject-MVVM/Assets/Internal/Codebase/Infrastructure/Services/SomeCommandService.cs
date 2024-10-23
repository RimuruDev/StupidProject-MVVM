using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Infrastructure.Services
{
    public class SomeCommandService : IDisposable
    {
        public SomeCommandService()
        {
            Debug.Log($"{GetType().Name} has been created!");
        }
        
        public void Dispose() => Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
    }
}