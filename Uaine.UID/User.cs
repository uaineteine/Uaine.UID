using System;
using Uaine.Objects.Primitives;

namespace Uaine.UID
{
    public class User : NamedObject
    {
        public UniqueID ID;
        public User(string name, bool posUniqueIDOnly) : base(name)
        {
            Random rand = new Random();
            ID = new UniqueID(ref rand, posUniqueIDOnly);
        }
    }
}
