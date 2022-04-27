using System;
using System.Threading.Tasks;

using R5T.T0021;
using R5T.T0064;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I001.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class DefaultSecretsJsonFileNameProvider : ISecretsJsonFileNameProvider, IServiceImplementation
    {
        public Task<string> GetSecretsJsonFileName()
        {
            return Task.FromResult(FileName.Instance.DefaultDatabaseConnectionConfigurationJsonFileName());
        }
    }
}
