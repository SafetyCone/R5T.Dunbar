using System;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public static class FilePathServicesAggregation02Extensions
    {
        public static FilePathServicesAggregation02 Include(this FilePathServicesAggregation02 aggregation02, FilePathServicesAggregation01 aggregation01)
        {
            aggregation02.DirectoryPathProviderAction = aggregation01.DirectoryPathProviderAction;
            aggregation02.JsonFilePathProviderAction = aggregation01.JsonFilePathProviderAction;
            aggregation02.SecretsJsonFilePathProviderAction = aggregation01.SecretsJsonFilePathProviderAction;

            return aggregation02;
        }
    }
}
