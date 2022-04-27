using System;
using System.Threading.Tasks;

using R5T.Suebia;

using R5T.T0064;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I003.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class SecretsJsonFilePathProvider : ISecretsJsonFilePathProvider, IServiceImplementation
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }
        private ISecretsJsonFileNameProvider SecretsJsonFileNameProvider { get; }


        public SecretsJsonFilePathProvider(
            ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider,
            ISecretsJsonFileNameProvider secretsJsonFileNameProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
            this.SecretsJsonFileNameProvider = secretsJsonFileNameProvider;
        }

        public async Task<string> GetSecretsJsonFilePath()
        {
            var fileName = await this.SecretsJsonFileNameProvider.GetSecretsJsonFileName();

            var filePath = await this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(fileName);
            return filePath;
        }
    }
}
