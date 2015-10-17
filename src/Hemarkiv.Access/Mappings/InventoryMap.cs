using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Hemarkiv.Access.Mappings
{
    public class InventoryMap : ClassMapping<Inventory>
    {

        public InventoryMap()
        {
            Lazy(true);
            Table("Inventarier");
            Id(x => x.Id, map => 
            {
                map.Column("ID");
                map.Generator(Generators.Native);
            });
            Property(x => x.Number, map =>
            {
                map.Column("Nummer");
                map.Length(8);
                map.Unique(true);
            });
            Property(x => x.Title, map =>
            {
                map.Column("Titel");
                map.Length(2147483647);
            });
            Property(x => x.Label, map =>
            {
                map.Column("Beteckning");
                map.Length(2147483647);
            });
            Property(x => x.SerialNumber, map =>
            {
                map.Column("Serienummer");
                map.Length(2147483647);
            });
            ManyToOne(x => x.Category, map =>
            {
                map.Column(cm =>
                {
                    cm.Name("Kategori");
                    cm.Length(8);
                });
                map.Cascade(Cascade.None);
                map.NotNullable(true);
                map.NotFound(NotFoundMode.Exception);
            });
            ManyToOne(x => x.OwnCategory, map =>
            {
                map.Column(cm =>
                {
                    cm.Name("[Egen kategori]");
                    cm.Length(8);
                });
                map.NotFound(NotFoundMode.Ignore);
            });
            Property(x => x.PurchaseYear, map => 
            {
                map.Column("Inköpsår");
                map.Length(8);
            });
            Property(x => x.Value, map => 
            {
                map.Column("Värde");
                map.Length(8);
            });
            Property(x => x.Lended, map => 
            {
                map.Column("Utlånad");
                map.Length(2147483647);
            });
            Property(x => x.Note, map =>
            {
                map.Column("Anteckningar");
                map.Length(2147483647);
            });
            Property(x => x.IsAntiTheftLabled, map => 
            {
                map.Column("AnvändStöldmärkning");
                map.Length(8);
            });
            Property(x => x.AntiTheftNumber, map => 
            {
                map.Column("Stöldmnr");
                map.Length(2147483647);
            });
            Property(x => x.DesignationNumber, map =>
            {
                map.Column("Tillvnr");
                map.Length(2147483647);
            });
            Property(x => x.Make, map =>
            {
                map.Column("Fabrikat");
                map.Length(2147483647);
            });
            Property(x => x.Freml, map => 
            {
                map.Column("Föremål");
                map.Length(2147483647);
            });
            Property(x => x.DeliveryValue, map => 
            {
                map.Column("Varuvärde");
                map.Length(8);
            });
            Property(x => x.Status, map =>
            {
                map.Column("Status");
                map.Length(8);
            });
        }
    }
}
