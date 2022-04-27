using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0022;
using R5T.T0064;

using R5T.Dunbar.T003;


namespace R5T.Dunbar.D002.I001
{
    [ServiceImplementationMarker]
    public class DatabaseConnectionConfigurationProvider : IDatabaseConnectionConfigurationProvider, IServiceImplementation
    {
        private IConfiguration Configuration { get; }


        public DatabaseConnectionConfigurationProvider(
            IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration()
        {
            var databaseConnectionConfigurationConfigurationSection = this.Configuration.GetSection(ConfigurationSectionNames.Instance.DatabaseConnectionConfiguration());

            var databaseConnectionConfiguration = databaseConnectionConfigurationConfigurationSection.Get<DatabaseConnectionConfiguration>();

            return Task.FromResult(databaseConnectionConfiguration);
        }
    }
}
