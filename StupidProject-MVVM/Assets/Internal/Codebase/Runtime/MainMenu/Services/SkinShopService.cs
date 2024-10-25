using System;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Services
{
    public class SkinShopService : IDisposable
    {
        public SkinShopService()
        {
            Debug.Log($"{GetType().Name} has been created!");
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}