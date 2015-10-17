using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Hemarkiv.Access.Mappings
{
    public class MovieMap : ClassMapping<Movie>
    {

        public MovieMap()
        {
            Lazy(true);
            Table("Film");
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
            Property(x => x.Director, map =>
            {
                map.Column("Regissör");
                map.Length(2147483647);
            });
            Property(x => x.Actor, map =>
            {
                map.Column("Skådespelare");
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
            Property(x => x.Grade, map =>
            {
                map.Column("Betyg");
                map.Length(8);
            });
            Property(x => x.StartTime, map =>
            {
                map.Column("Starttid");
                map.Length(8);
            });
            Property(x => x.PlayingTime, map =>
            {
                map.Column("Speltid");
                map.Length(8);
            });
            Property(x => x.TapeLength, map =>
            {
                map.Column("Bandtid");
                map.Length(8);
            });
            Property(x => x.Recorded, map =>
            {
                map.Column("Inspelad");
                map.Length(8);
            });
            Property(x => x.Value, map => 
            {
                map.Column("Värde");
                map.Length(8); });
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
