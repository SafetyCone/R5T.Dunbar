using System;

using R5T.Dacia;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class FilePathServicesAggregation01
    {
        public IServiceAction<IDirectoryPathProvider> DirectoryPathProviderAction { get; set; }
        public IServiceAction<IJsonFilePathProvider> JsonFilePathProviderAction { get; set; }
        public IServiceAction<ISecretsJsonFilePathProvider> SecretsJsonFilePathProviderAction { get; set; }
    }
}
