using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.Dunbar.D002;


namespace R5T.Dunbar.Construction.Operations
{
    public class GetRawDatabaseConnectionConfiguration : IOperation
    {
        private IDatabaseConnectionConfigurationProvider DatabaseConnectionConfigurationProvider { get; }


        public GetRawDatabaseConnectionConfiguration(
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
