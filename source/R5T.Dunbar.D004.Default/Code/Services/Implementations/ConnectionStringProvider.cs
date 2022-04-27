using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.Dunbar.D003;


namespace R5T.Dunbar.D004
{
    [ServiceImplementationMarker]
    public class ConnectionStringProvider : IConnectionStringProvider, IServiceImplementation
    {
        private IDatabaseConnectionConfigurationProvider DatabaseConnectionConfigurationProvider { get; }


        public ConnectionStringProvider(
            IDatabaseConnectionConfigurationProvider databaseConnectionConfigurationProvider)
        {
            this.DatabaseConnectionConfigurationProvider = databaseConnectionConfigurationProvider;
        }

        public async Task<string> GetConnectionString()
        {
            var databaseConnectionConfiguration = await this.DatabaseConnectionConfigurationProvider.GetDatabaseConnectionConfiguration();

            var connectionString = databaseConnectionConfiguration.GetConnectionString();

            return connectionString.Value;
        }
    }
}
