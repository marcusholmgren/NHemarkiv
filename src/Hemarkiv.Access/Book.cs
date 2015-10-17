namespace Hemarkiv.Access
{
    public class Book
    {
        public virtual int? Id { get; protected set; }
        public virtual int? Number { get; protected set; }
        public virtual string Author { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual Category Category { get; protected set; }
        public virtual Category OwnCategory { get; protected set; }
        public virtual int? PageCount { get; protected set; }
        public virtual double? Value { get; protected set; }
        public virtual string Lended { get; protected set; }
        public virtual string Note { get; protected set; }
    }
}
