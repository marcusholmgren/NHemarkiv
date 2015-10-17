using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hemarkiv.Access
{
    public sealed class ConfigurationBuilder
    {
        const string Serialized_cfg = "configuration.bin";
        
        public Configuration Build()
        {
            Configuration cfg = LoadConfigurationFromFile();
            if (cfg == null)
            {
                cfg = ConfigureNHibernate();
                SaveConfigurationToFile(cfg);
            }
            return cfg;
        }


        static Configuration ConfigureNHibernate()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("HemArkivAccess");

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<NHibernate.JetDriver.JetDialect>();
                db.Driver<NHibernate.JetDriver.JetDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;

                db.ConnectionStringName = "HemArkivAccess";
                db.Timeout = 10;

                // enabled for testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = false;
                db.AutoCommentSql = false;
                db.Timeout = 10;
                //db.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
            });


            var mapping = GetMappings();
            configure.AddDeserializedMapping(mapping, "HemArkivAccess");

            return configure;
        }

        static HbmMapping GetMappings()
        {
            var mapper = new NHibernate.Mapping.ByCode.ModelMapper();

            mapper.AddMappings(Assembly.GetAssembly(typeof(Mappings.CategoryMap)).GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }


        Configuration LoadConfigurationFromFile()
        {
            if (!IsConfigurationFileValid())
                return null;
            try
            {
                using (var file = File.Open(Serialized_cfg, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    return bf.Deserialize(file) as Configuration;
                }
            }
            catch (Exception)
            {
                // Something went wrong
                // Just build a new one
                return null;
            }
        }

        bool IsConfigurationFileValid()
        {
            // If we don't have a cached config,
            // force a new one to be built
            if (!File.Exists(Serialized_cfg))
                return false;
            var configInfo = new FileInfo(Serialized_cfg);
            var asm = Assembly.GetExecutingAssembly();
            if (asm.Location == null)
                return false;
            // If the assembly is newer,
            // the serialized config is stale
            var asmInfo = new FileInfo(asm.Location);
            if (asmInfo.LastWriteTime > configInfo.LastWriteTime)
                return false;
            // If the app.config is newer,
            // the serialized config is stale
            var appDomain = AppDomain.CurrentDomain;
            var appConfigPath = appDomain.SetupInformation.
                ConfigurationFile;
            var appConfigInfo = new FileInfo(appConfigPath);
            if (appConfigInfo.LastWriteTime > configInfo.LastWriteTime)
                return false;
            // It's still fresh
            return true;
        }

        void SaveConfigurationToFile(Configuration cfg)
        {
            using (var file = File.Open(Serialized_cfg, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, cfg);
            }
        }
    }
}
