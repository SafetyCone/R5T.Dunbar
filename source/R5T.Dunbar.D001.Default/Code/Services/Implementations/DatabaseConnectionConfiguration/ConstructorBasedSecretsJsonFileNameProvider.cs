using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class ConstructorBasedSecretsJsonFileNameProvider : ISecretsJsonFileNameProvider
    {
        private string SecretsJsonFileName { get; }


        public ConstructorBasedSecretsJsonFileNameProvider(
            string secretsJsonFileName)
        {
            this.SecretsJsonFileName = secretsJsonFileName;
        }

        public Task<string> GetSecretsJsonFileName()
        {
            return Task.FromResult(this.SecretsJsonFileName);
        }
    }
}
