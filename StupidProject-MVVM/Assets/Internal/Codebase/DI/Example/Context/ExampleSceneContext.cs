using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.DI.Example.Services;
using UnityEngine;

namespace AbyssMoth.Internal.Codebase.DI.Example.Context
{
    [DisallowMultipleComponent]
    public sealed class ExampleSceneContext : MonoBehaviour
    {
        public void Initialize(DIContainer container)
        {
            var serviceWithoutTag = container.Resolve<StaticDataProjectService>();
            var serviceWithTagOne = container.Resolve<StaticDataProjectService>("Tower of Defence");
            var serviceWithTagTwo = container.Resolve<CoroutineRunnerProjectService>("Gameplay");
        }
    }
}