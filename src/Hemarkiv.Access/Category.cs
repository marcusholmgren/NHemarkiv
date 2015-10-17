using System.Collections.Generic;

namespace Hemarkiv.Access
{
    public class Category
    {
        public virtual int Id { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual CategoryType Type { get; protected set; }
        public virtual int? Index { get; protected set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
