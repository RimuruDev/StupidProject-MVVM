using UnityEngine;

namespace AbyssMoth.Internal.Codebase.DI.Example.Factorys
{
    public sealed class HeroFactory
    {
        public PawnObject CreateInstance(string id, string owner)
        {
            return new PawnObject(id, owner);
        }
    }
}