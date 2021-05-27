using System;
using System.Threading.Tasks;

using R5T.Dunbar.D003;


namespace R5T.Dunbar.D005
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private IDatabaseConnectionConfigurationProvider DatabaseConnectionConfigurationProvider { get; }


        public ConnectionStringProvider(
            IDatabaseConnectionConfigurationProvider databaseConnectionConfigurationProvider)
        {
            this.DatabaseConnectionConfigurationProvider = databaseConnectionConfigurationProvider;
        }

        public async Task<string> GetConnectionString(string databaseName)
        {
            var databaseConnectionConfiguration = await this.DatabaseConnectionConfigurationProvider.GetDatabaseConnectionConfiguration();

            var connectionString = databaseConnectionConfiguration.GetConnectionString(databaseName);

            return connectionString.Value;
        }
    }
}
