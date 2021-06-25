using System;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Suebia.Standard;

using R5T.D0065.Standard;
using R5T.D0070.Standard;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;

using R5T.Dunbar.A001.Operations;


namespace R5T.Dunbar.A001
{
    public class DefaultConfigurationServicesAggregation01
    {
        public PathRelatedOperatorsAggregation01 PathRelatedOperators { get; set; }
        public ExecutableDirectoryPathAggregation02 ExecutableDirectoryPathServices { get; set; }
        public AppSettingsFilePathAggregation01 AppSettingsFilePathServices { get; set; }
        public SecretsDirectoryFilePathAggregation01 SecretsDirectoryFilePathServices { get; set; }
        public FilePathServicesAggregation02 DatabaseConnectionConfigurationFilePathServicesAggregation { get; set; }
        public IServiceAction<AddDatabaseConnectionConfigurationJsonFilePaths> AddDatabaseConnectionConfigurationJsonFilePathsAction { get; set; }
    }
}
