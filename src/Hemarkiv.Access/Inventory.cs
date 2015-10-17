namespace Hemarkiv.Access
{
    public class Inventory
    {
        public virtual int? Id { get; protected set; }
        public virtual int? Number { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual string Label { get; protected set; }
        public virtual string SerialNumber { get; protected set; }
        public virtual Category Category { get; protected set; }
        public virtual Category OwnCategory { get; protected set; }
        public virtual int? PurchaseYear { get; protected set; }
        public virtual decimal? Value { get; protected set; }
        public virtual string Lended { get; protected set; }
        public virtual string Note { get; protected set; }
        public virtual bool IsAntiTheftLabled { get; protected set; }
        public virtual string AntiTheftNumber { get; protected set; }
        public virtual string DesignationNumber { get; protected set; }
        public virtual string Make { get; protected set; }
        public virtual string Freml { get; protected set; }
        public virtual decimal? DeliveryValue { get; protected set; }
        public virtual int? Status { get; protected set; }

        public override string ToString()
        {
            return string.Format("[{0}: {1} ({2})]", GetType().Name, Title, Number);
        }
    }
}
