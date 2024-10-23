using System;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services
{
    public class GameplayStatisticsService : IDisposable
    {
        private SomeCommandService someCommandService;

        public GameplayStatisticsService(SomeCommandService someCommandService)
        {
            this.someCommandService = someCommandService;
            Debug.Log($"{GetType().Name} has been created!");
        }

        public void Dispose()
        {
            Debug.Log($"<color=yellow>{GetType().Name} Dispose!</color>");
        }
    }
}