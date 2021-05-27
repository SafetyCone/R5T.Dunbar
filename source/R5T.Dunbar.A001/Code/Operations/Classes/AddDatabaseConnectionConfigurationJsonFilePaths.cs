using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0020;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.A001.Operations
{
    public class AddDatabaseConnectionConfigurationJsonFilePaths : IActionOperation<IConfigurationBuilder>
    {
        private IJsonFilePathProvider JsonFilePathProvider { get; }
        private ISecretsJsonFilePathProvider SecretsJsonFilePathProvider { get;}


        public AddDatabaseConnectionConfigurationJsonFilePaths(
            IJsonFilePathProvider jsonFilePathProvider,
            ISecretsJsonFilePathProvider secretsJsonFilePathProvider)
        {
            this.JsonFilePathProvider = jsonFilePathProvider;
            this.SecretsJsonFilePathProvider = secretsJsonFilePathProvider;
        }

        public async Task Run(IConfigurationBuilder configurationBuilder)
        {
            var jsonFilePath = await this.JsonFilePathProvider.GetJsonFilePath();
            var secretsJsonFilePath = await this.SecretsJsonFilePathProvider.GetSecretsJsonFilePath();

            configurationBuilder
                .AddJsonFile(jsonFilePath)
                .AddJsonFile(secretsJsonFilePath)
                ;
        }
    }
}
