using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class UIGameplayRootViewModel
    {
        private SomeCommandService someCommandService;

        public UIGameplayRootViewModel(SomeCommandService someCommandService)
        {
            this.someCommandService = someCommandService;
            
            Debug.Log($"{GetType().Name} has been created!");
        }
    }
}