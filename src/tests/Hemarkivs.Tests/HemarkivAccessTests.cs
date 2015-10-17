using Hemarkiv.Access;
using log4net;
using NHibernate.Linq;
using System.Reflection;
using System.Linq;
using Xunit;

namespace Hemarkivs.Tests
{
    public class HemarkiveAccessTests
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Fact]
        public void CategoryTypesContainsEntries()
        {
            var cfg = new ConfigurationBuilder();
            using (var factory = cfg.Build().BuildSessionFactory())
            using (var session = factory.OpenSession())
            {
                var entities = session.Query<Category>()
                    .AsEnumerable()
                    .GroupBy(x => x.Type, x => x)
                    .Select(x => new { Type = x.Key, Count = x.Count() });

                Assert.NotEqual(0, entities.Count());
            }
        }
    }
}
