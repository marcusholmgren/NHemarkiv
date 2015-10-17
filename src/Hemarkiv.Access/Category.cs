using System.Collections.Generic;

namespace Hemarkiv.Access
{
    public class Category
    {
        public virtual int Id { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual CategoryType Type { get; protected set; }
        public virtual int? Index { get; protected set; }

        ICollection<Book> _books = null;
        public virtual IEnumerable<Book> Books { get { return _books; } }

        ICollection<Music> _music = null;
        public virtual IEnumerable<Music> Music { get { return _music; } }

        ICollection<Movie> _movies = null;
        public virtual IEnumerable<Movie> Movies { get { return _movies; } }

        ICollection<Inventory> _inventoryItems = null;
        public virtual IEnumerable<Inventory> InventoryItems { get { return _inventoryItems; } }

        public override string ToString()
        {
            return Description;
        }
    }
}
