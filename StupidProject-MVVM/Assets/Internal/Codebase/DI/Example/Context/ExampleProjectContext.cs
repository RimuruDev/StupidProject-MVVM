using UnityEngine;
// using AbyssMoth.Internal.Codebase.DI.Container;
// using AbyssMoth.Internal.Codebase.DI.Example.Services;

namespace AbyssMoth.Internal.Codebase.DI.Example.Context
{
    [DisallowMultipleComponent]
    public sealed class ExampleProjectContext : MonoBehaviour
    {
        [SerializeField] private ExampleSceneContext exampleSceneContext;
        
        // private void Awake()
        // {
        //     var projectContainer = new DIContainer();
        //     
        //     // Lazy registration singleton
        //     projectContainer.RegisterSingleton(_ => new StaticDataProjectService());
        //     projectContainer.RegisterSingleton(_ => new CoroutineRunnerProjectService());
        //     
        //     // Lazy registration singleton with tag
        //     projectContainer.RegisterSingleton("Tower of Defence",_ => new StaticDataProjectService());
        //     projectContainer.RegisterSingleton("Gameplay",_ => new CoroutineRunnerProjectService());
        //     
        //     // Initialize hardcode scene context
        //     exampleSceneContext.Initialize(projectContainer);
        // }
    }
}