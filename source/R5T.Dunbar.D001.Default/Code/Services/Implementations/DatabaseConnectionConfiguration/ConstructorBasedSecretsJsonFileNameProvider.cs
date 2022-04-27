using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class ConstructorBasedSecretsJsonFileNameProvider : ISecretsJsonFileNameProvider, IServiceImplementation
    {
        private string SecretsJsonFileName { get; }


        public ConstructorBasedSecretsJsonFileNameProvider(
            [NotServiceComponent] string secretsJsonFileName)
        {
            this.SecretsJsonFileName = secretsJsonFileName;
        }

        public Task<string> GetSecretsJsonFileName()
        {
            return Task.FromResult(this.SecretsJsonFileName);
        }
    }
}
