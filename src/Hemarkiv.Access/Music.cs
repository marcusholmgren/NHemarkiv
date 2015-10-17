namespace Hemarkiv.Access
{
    public class Music
    {
        public virtual int Id { get; protected set; }
        public virtual int? Number { get; protected set; }
        public virtual string Artist { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual MusicMedia Media { get; protected set; }
        public virtual Category Category { get; protected set; }
        public virtual Category OwnCategory { get; protected set; }
        public virtual string SideA { get; protected set; }
        public virtual string SideB { get; protected set; }
        public virtual decimal? Value { get; protected set; }
        public virtual string Lended { get; protected set; }
        public virtual string Note { get; protected set; }
    }
}
