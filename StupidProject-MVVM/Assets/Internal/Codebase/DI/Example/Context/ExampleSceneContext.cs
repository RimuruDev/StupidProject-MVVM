using UnityEngine;
using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.DI.Example.Factorys;
using AbyssMoth.Internal.Codebase.DI.Example.Services;

namespace AbyssMoth.Internal.Codebase.DI.Example.Context
{
    [DisallowMultipleComponent]
    public sealed class ExampleSceneContext : MonoBehaviour
    {
        // public void Initialize(DIContainer projectContainer)
        // {
        //     var sceneContainer = new DIContainer(projectContainer);
        //     sceneContainer.RegisterSingleton(c => new EnemySceneService(c.Resolve<StaticDataProjectService>(), c.Resolve<CoroutineRunnerProjectService>("Gameplay")));
        //     sceneContainer.RegisterSingleton(_ => new HeroFactory());
        //     sceneContainer.RegisterInstance(new PawnObject("666", "Adam"));
        //
        //     var objectFactory = sceneContainer.Resolve<HeroFactory>();
        //     var result = objectFactory.CreateInstance("Test", "Bot");
        //     Debug.Log($"result: {result.id} | {result.owner}");
        //
        //     var registeredPawn = sceneContainer.Resolve<PawnObject>();
        //     Debug.Log($"result: {registeredPawn.id} | {registeredPawn.owner}");
        // }
    }
}