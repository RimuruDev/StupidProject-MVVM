namespace AbyssMoth.Internal.Codebase.DI.Example.Factorys
{
    public sealed class PawnObject
    {
        public readonly string id;
        public readonly string owner;

        public PawnObject(string id, string owner)
        {
            this.owner = owner;
            this.id = id;
        }
    }
}