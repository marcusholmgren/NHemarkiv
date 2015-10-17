using Hemarkiv.Access;
using log4net;
using NHibernate.Linq;
using System.Reflection;
using System.Linq;
using Xunit;
using System;
using NHibernate;

namespace Hemarkivs.Tests
{
    public class HemarkiveAccessTests : IDisposable
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly Lazy<ISessionFactory> factory = new Lazy<ISessionFactory>(() => new ConfigurationBuilder().Build().BuildSessionFactory());

        [Fact]
        public void CategoryTypesContainsEntries()
        {
            using (var session = factory.Value.OpenSession())
            {
                var entities = session.Query<Category>()
                    .AsEnumerable()
                    .GroupBy(x => x.Type, x => x)
                    .Select(x => new { Type = x.Key, Count = x.Count() });

                Assert.NotEqual(0, entities.Count());
            }
        }


        [Fact]
        public void BookContainsEntries()
        {
            using (var session = factory.Value.OpenSession())
            {
                var entities = session.QueryOver<Book>()
                    .Fetch(x => x.Category).Eager
                    .Fetch(x => x.OwnCategory).Eager
                    .List();

                Assert.NotEqual(0, entities.Count);
            }
        }


        [Fact]
        public void InventoryContainsEntries()
        {
            using (var session = factory.Value.OpenSession())
            {
                var entities = session.QueryOver<Inventory>()
                    .Fetch(x => x.Category).Eager
                    .Fetch(x => x.OwnCategory).Eager
                    .List();

                Assert.NotEqual(0, entities.Count);
            }
        }


        [Fact]
        public void MovieContainsEntries()
        {
            using (var session = factory.Value.OpenSession())
            {
                var entities = session.QueryOver<Movie>()
                    .Fetch(x => x.Category).Eager
                    .Fetch(x => x.OwnCategory).Eager
                    .List();

                Assert.NotEqual(0, entities.Count);
            }
        }

        
        [Fact]
        public void MusicContainsEntries()
        {
            using (var session = factory.Value.OpenSession())
            {
                var entities = session.QueryOver<Music>()
                    .Fetch(x => x.Category).Eager
                    .Fetch(x => x.OwnCategory).Eager
                    .List();

                Assert.NotEqual(0, entities.Count);
            }
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (factory.IsValueCreated)
                        factory.Value.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~HemarkiveAccessTests() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
