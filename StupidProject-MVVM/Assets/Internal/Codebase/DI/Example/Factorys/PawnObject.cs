namespace AbyssMoth.Internal.Codebase.DI.Example.Factorys
{
    public sealed class PawnObject
    {
        private readonly string id;
        private readonly string owner;

        public PawnObject(string id, string owner)
        {
            this.owner = owner;
            this.id = id;
        }
    }
}