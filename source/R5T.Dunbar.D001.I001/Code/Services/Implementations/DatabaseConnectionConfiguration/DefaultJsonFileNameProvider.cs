using System;
using System.Threading.Tasks;

using R5T.T0021;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I001.DatabaseConnectionConfiguration
{
    public class DefaultJsonFileNameProvider : IJsonFileNameProvider
    {
        public Task<string> GetJsonFileName()
        {
            return Task.FromResult(FileNames.Instance.DefaultDatabaseConnectionConfigurationJsonFileName());
        }
    }
}
