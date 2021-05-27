using System;
using System.Threading.Tasks;

namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class ConstructorBasedJsonFilePathProvider : IJsonFilePathProvider
    {
        private string JsonFilePath { get; }


        public ConstructorBasedJsonFilePathProvider(
            string jsonFilePath)
        {
            this.JsonFilePath = jsonFilePath;
        }

        public Task<string> GetJsonFilePath()
        {
            return Task.FromResult(this.JsonFilePath);
        }
    }
}
