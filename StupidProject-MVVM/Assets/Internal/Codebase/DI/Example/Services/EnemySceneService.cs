namespace AbyssMoth.Internal.Codebase.DI.Example.Services
{
    public sealed class EnemySceneService
    {
        private StaticDataProjectService staticDataService;
        private CoroutineRunnerProjectService coroutineRunner;

        public EnemySceneService(StaticDataProjectService staticDataService, CoroutineRunnerProjectService coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
            this.staticDataService = staticDataService;
        }
    }
}