using R5T.Dacia;
using System;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class FilePathServicesAggregation02 : FilePathServicesAggregation01
    {
        public IServiceAction<IJsonFileNameProvider> JsonFileNameProviderAction { get; set; }
        public IServiceAction<ISecretsJsonFileNameProvider> SecretsJsonFileNameProviderAction { get; set; }
    }
}
