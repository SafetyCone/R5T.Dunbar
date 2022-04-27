using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class ConstructorBasedJsonFilePathProvider : IJsonFilePathProvider, IServiceImplementation
    {
        private string JsonFilePath { get; }


        public ConstructorBasedJsonFilePathProvider(
            [NotServiceComponent] string jsonFilePath)
        {
            this.JsonFilePath = jsonFilePath;
        }

        public Task<string> GetJsonFilePath()
        {
            return Task.FromResult(this.JsonFilePath);
        }
    }
}
