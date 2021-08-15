using System;
using Uaine.Objects.Primitives;
using Uaine.Random;

namespace Uaine.UID
{
    public class User : NamedObject
    {
        public UniqueID ID;
        public User(string name, bool posUniqueIDOnly) : base(name)
        {
            URandom rand = new URandom();
            ID = new UniqueID(posUniqueIDOnly);
        }
    }
}
