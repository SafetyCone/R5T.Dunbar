using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Suebia;

using R5T.D0070;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;

using R5T.Dunbar.D001;
using R5T.Dunbar.D001.I001;
using R5T.Dunbar.D001.I002;
using R5T.Dunbar.D001.I003;


namespace R5T.Dunbar.D001.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static FilePathServicesAggregation01 AddDatabaseConnectionConfigurationFilePathServicesAction(this IServiceCollection services,
            IServiceAction<IAppSettingsDirectoryPathProvider> appSettingsDirectoryPathProviderAction,
            IServiceAction<IJsonFileNameProvider> jsonFileNameProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<ISecretsJsonFileNameProvider> secretsJsonFileNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 1.
            var directoryPathProviderAction = services.AddDirectoryPathProviderAction(
                appSettingsDirectoryPathProviderAction);

            // Level 2.
            var jsonFilePathProviderAction = services.AddJsonFilePathProviderAction(
                directoryPathProviderAction,
                jsonFileNameProviderAction,
                stringlyTypedPathOperatorAction);

            var secretsJsonFilePathProviderAction = services.AddSecretsJsonFilePathProviderAction(
                secretsDirectoryFilePathProviderAction,
                secretsJsonFileNameProviderAction);

            return new FilePathServicesAggregation01
            {
                DirectoryPathProviderAction = directoryPathProviderAction,
                JsonFilePathProviderAction = jsonFilePathProviderAction,
                SecretsJsonFilePathProviderAction = secretsJsonFilePathProviderAction,
            };
        }

        public static FilePathServicesAggregation02 AddDatabaseConnectionConfigurationFilePathServicesAction(this IServiceCollection services,
            IServiceAction<IAppSettingsDirectoryPathProvider> appSettingsDirectoryPathProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 0.
            var jsonFileNameProviderAction = services.AddDefaultJsonFileNameProviderAction();
            var secretsJsonFileNameProviderAction = services.AddDefaultSecretsJsonFileNameProviderAction();

            var aggration01 = services.AddDatabaseConnectionConfigurationFilePathServicesAction(
                appSettingsDirectoryPathProviderAction,
                jsonFileNameProviderAction,
                secretsDirectoryFilePathProviderAction,
                secretsJsonFileNameProviderAction,
                stringlyTypedPathOperatorAction);

            return new FilePathServicesAggregation02
            {
                JsonFileNameProviderAction = jsonFileNameProviderAction,
                SecretsJsonFileNameProviderAction = secretsJsonFileNameProviderAction,
            }
            .Include(aggration01);
        }
    }
}
