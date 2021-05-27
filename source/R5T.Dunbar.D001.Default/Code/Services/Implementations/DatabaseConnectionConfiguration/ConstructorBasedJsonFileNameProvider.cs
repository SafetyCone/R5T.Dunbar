using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class ConstructorBasedJsonFileNameProvider : IJsonFileNameProvider
    {
        private string JsonFileName { get; }


        public ConstructorBasedJsonFileNameProvider(
            string jsonFileName)
        {
            this.JsonFileName = jsonFileName;
        }

        public Task<string> GetJsonFileName()
        {
            return Task.FromResult(this.JsonFileName);
        }
    }
}
