using System;

namespace AbyssMoth.Internal.Codebase.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class NoteAttribute : Attribute
    {
        public NoteAttribute()
        {
        }

        public NoteAttribute(string description)
        {
        }
    }
}