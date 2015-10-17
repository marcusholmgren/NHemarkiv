using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Hemarkiv.Access.Mappings
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Lazy(true);
            Table("Kategorier");
            Id(x => x.Id, map =>
            {
                map.Column("Kategori");
                map.Generator(Generators.Native);
            });
            Property(x => x.Description, map =>
            {
                map.Column("Benämning");
                map.Length(2147483647);
            });
            Property(x => x.Type, map =>
            {
                map.Column("Typ");
                map.Length(8);
            });
            Property(x => x.Index, map =>
            {
                map.Column("Index");
                map.Length(8);
            });

            Set(x => x.Books, map =>
                {
                    map.Lazy(CollectionLazy.Lazy);
                    map.Access(Accessor.Field);
                    map.Key(fk =>
                    {
                        fk.Column("Kategori");
                    });
                    map.Cascade(Cascade.None);
                    map.Inverse(true);
                },
                map => map.OneToMany(x =>
                {
                    x.NotFound(NotFoundMode.Ignore);
                }
            ));
            Set(x => x.Movies,
               map =>
               {
                   map.Lazy(CollectionLazy.Lazy);
                   map.Access(Accessor.Field);
                   map.Key(fk =>
                   {
                       fk.Column("Kategori");
                   });
                   map.Cascade(Cascade.None);
                   map.Inverse(true);
               },
               map => map.OneToMany(x =>
               {
                   x.NotFound(NotFoundMode.Ignore);
               }
           ));
            Set(x => x.InventoryItems,
                map =>
                {
                    map.Lazy(CollectionLazy.Lazy);
                    map.Access(Accessor.Field);
                    map.Key(fk =>
                    {
                        fk.Column("Kategori");
                    });
                    map.Cascade(Cascade.None);
                    map.Inverse(true);
                },
                map => map.OneToMany(x =>
                {
                    x.NotFound(NotFoundMode.Ignore);
                }
            ));
            Set(x => x.Music,
                map =>
                {
                    map.Lazy(CollectionLazy.Lazy);
                    map.Access(Accessor.Field);
                    map.Key(fk =>
                    {
                        fk.Column("Kategori");
                    });
                    map.Cascade(Cascade.None);
                    map.Inverse(true);
                },
                map => map.OneToMany(x =>
                {
                    x.NotFound(NotFoundMode.Ignore);
                }
            ));
        }
    }
}
