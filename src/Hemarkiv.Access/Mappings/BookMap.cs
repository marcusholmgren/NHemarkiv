using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Hemarkiv.Access.Mappings
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Lazy(true);
            Table("Böcker");
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
            Property(x => x.Author, map =>
            {
                map.Column("Författare");
                map.Length(2147483647);
            });
            Property(x => x.Title, map =>
            {
                map.Column("Titel");
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
                map.Cascade(Cascade.None);
                map.NotFound(NotFoundMode.Ignore);
            });
            Property(x => x.PageCount, map => 
            {
                map.Column("[Antal Sidor]");
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
        }
    }
}
