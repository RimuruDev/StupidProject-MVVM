using System;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Services
{
    public class SkinShopService : IDisposable
    {
        private SomeCommandService someCommandService;

        public SkinShopService(SomeCommandService someCommandService)
        {
            this.someCommandService = someCommandService;
            Debug.Log($"{GetType().Name} has been created!");
        }
        
        public void Dispose()
        {
            Debug.Log($"{GetType().Name} Dispose!");
        }
    }
}