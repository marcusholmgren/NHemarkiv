using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Hemarkiv.Access.Mappings
{
    public class MusicMap : ClassMapping<Music>
    {

        public MusicMap()
        {
            Lazy(true);
            Table("Musik");
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
            Property(x => x.Artist, map =>
            {
                map.Column("Artist");
                map.Length(2147483647);
            });
            Property(x => x.Title, map =>
            {
                map.Column("Titel");
                map.Length(2147483647);
            });
            Property(x => x.Media, map =>
            {
                map.Column("Media");
                map.Length(8);
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
            Property(x => x.SideA, map => 
            {
                map.Column("[Sida A]");
                map.Length(2147483647);
            });
            Property(x => x.SideB, map => 
            {
                map.Column("[Sida B]");
                map.Length(2147483647);
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
