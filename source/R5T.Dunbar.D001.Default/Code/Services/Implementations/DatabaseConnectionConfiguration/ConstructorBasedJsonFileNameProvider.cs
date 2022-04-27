using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class ConstructorBasedJsonFileNameProvider : IJsonFileNameProvider, IServiceImplementation
    {
        private string JsonFileName { get; }


        public ConstructorBasedJsonFileNameProvider(
            [NotServiceComponent] string jsonFileName)
        {
            this.JsonFileName = jsonFileName;
        }

        public Task<string> GetJsonFileName()
        {
            return Task.FromResult(this.JsonFileName);
        }
    }
}
