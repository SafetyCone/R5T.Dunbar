using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.Dunbar.D003;


namespace R5T.Dunbar.Construction.Operations
{
    public class GetDatabaseConnectionConfiguration : IOperation
    {
        private IDatabaseConnectionConfigurationProvider DatabaseConnectionConfigurationProvider { get; }


        public GetDatabaseConnectionConfiguration(
            IDatabaseConnectionConfigurationProvider databaseConnectionConfigurationProvider)
        {
            this.DatabaseConnectionConfigurationProvider = databaseConnectionConfigurationProvider;
        }

        public async Task Run()
        {
            var databaseConnectionConfiguration = await this.DatabaseConnectionConfigurationProvider.GetDatabaseConnectionConfiguration();
        }
    }
}
