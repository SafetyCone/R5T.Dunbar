using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0064;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class JsonFilePathProvider : IJsonFilePathProvider, IServiceImplementation
    {
        private IDirectoryPathProvider DirectoryPathProvider { get; }
        private IJsonFileNameProvider JsonFileNameProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public JsonFilePathProvider(
            IDirectoryPathProvider directoryPathProvider,
            IJsonFileNameProvider jsonFileNameProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DirectoryPathProvider = directoryPathProvider;
            this.JsonFileNameProvider = jsonFileNameProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetJsonFilePath()
        {
            var directoryPath = await this.DirectoryPathProvider.GetDirectoryPath();
            var fileName = await this.JsonFileNameProvider.GetJsonFileName();

            var filePath = this.StringlyTypedPathOperator.GetFilePath(directoryPath, fileName);
            return filePath;
        }
    }
}
