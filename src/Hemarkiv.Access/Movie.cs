namespace Hemarkiv.Access
{
    public class Movie
    {
        public virtual int? Id { get; protected set; }
        public virtual int? Number { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual string Director { get; protected set; }
        public virtual string Actor { get; protected set; }
        public virtual int? Media { get; protected set; }
        public virtual Category Category { get; protected set; }
        public virtual Category OwnCategory { get; protected set; }
        public virtual int? Grade { get; protected set; }
        public virtual int? StartTime { get; protected set; }
        public virtual int? PlayingTime { get; protected set; }
        public virtual int? TapeLength { get; protected set; }
        public virtual int? Recorded { get; protected set; }
        public virtual double? Value { get; protected set; }
        public virtual string Lended { get; protected set; }
        public virtual string Note { get; protected set; }
    }
}
