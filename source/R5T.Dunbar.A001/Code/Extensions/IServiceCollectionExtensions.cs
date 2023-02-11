using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;
using R5T.Suebia.Standard;

using R5T.D0065;
using R5T.D0065.Standard;
using R5T.D0070.Default;
using R5T.D0070.Standard;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;
using R5T.Dunbar.D001.Standard;
using R5T.Dunbar.D003;
using R5T.Dunbar.D003.I001;
using R5T.Dunbar.D004;
using R5T.Dunbar.D005;

using R5T.Dunbar.A001.Operations;

using IConnectionStringProviderParameterized = R5T.Dunbar.D005.IConnectionStringProvider;
using IConnectionStringProviderParameterless = R5T.Dunbar.D004.IConnectionStringProvider;


namespace R5T.Dunbar.A001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AddDatabaseConnectionConfigurationJsonFilePaths"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAddDatabaseConnectionConfigurationJsonFilePaths(this IServiceCollection services,
            IServiceAction<IJsonFilePathProvider> jsonFilePathProviderAction,
            IServiceAction<ISecretsJsonFilePathProvider> secretsJsonFilePathProviderAction)
        {
            services.AddSingleton<AddDatabaseConnectionConfigurationJsonFilePaths>()
                .Run(jsonFilePathProviderAction)
                .Run(secretsJsonFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AddDatabaseConnectionConfigurationJsonFilePaths"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<AddDatabaseConnectionConfigurationJsonFilePaths> AddAddDatabaseConnectionConfigurationJsonFilePathsAction(this IServiceCollection services,
            IServiceAction<IJsonFilePathProvider> jsonFilePathProviderAction,
            IServiceAction<ISecretsJsonFilePathProvider> secretsJsonFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<AddDatabaseConnectionConfigurationJsonFilePaths>(() => services.AddAddDatabaseConnectionConfigurationJsonFilePaths(
                jsonFilePathProviderAction,
                secretsJsonFilePathProviderAction));

            return serviceAction;
        }

        public static DefaultConfigurationServicesAggregation01 AddDefaultConfigurationServiceActions(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            // Level 0.
            var pathRelatedOperatorsAction = services.AddPathRelatedOperatorsAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);
            var secretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryPathProviderAction(
                organizationProviderAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Level 2.
            var appSettingsFilePathProviderAction = services.AddDefaultJsonAppSettingsFileNameProviderAction(
                pathRelatedOperatorsAction.FileNameOperatorAction);

            // Level 3.
            var databaseConnectionConfigurationFilePathServicesAggregation = services.AddDatabaseConnectionConfigurationFilePathServicesAction(
                appSettingsFilePathProviderAction,
                secretsDirectoryFilePathProviderAction.SecretsDirectoryPathProviderAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Operations.
            var addDatabaseConnectionConfigurationJsonFilePathsAction = services.AddAddDatabaseConnectionConfigurationJsonFilePathsAction(
                databaseConnectionConfigurationFilePathServicesAggregation.JsonFilePathProviderAction,
                databaseConnectionConfigurationFilePathServicesAggregation.SecretsJsonFilePathProviderAction);

            return new DefaultConfigurationServicesAggregation01
            {
                AddDatabaseConnectionConfigurationJsonFilePathsAction = addDatabaseConnectionConfigurationJsonFilePathsAction,
                AppSettingsFilePathServices = appSettingsFilePathProviderAction,
                DatabaseConnectionConfigurationFilePathServicesAggregation = databaseConnectionConfigurationFilePathServicesAggregation,
                ExecutableDirectoryPathServices = executableDirectoryPathProviderAction,
                PathRelatedOperators = pathRelatedOperatorsAction,
                SecretsDirectoryFilePathServices = secretsDirectoryFilePathProviderAction,
            };
        }

        public static
            (
            IServiceAction<IDatabaseConnectionConfigurationProvider> DatabaseConnectionConfigurationProviderAction,
            IServiceAction<IConnectionStringProviderParameterized> ParameterizedConnectionStringProviderAction,
            IServiceAction<IConnectionStringProviderParameterless> ParameterlessConnectionStringProviderAction
            )
        AddDatabaseConnectionConfigurationActions(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Level 0.

            // Level 1.
            var databaseConnectionConfigurationProviderAction = services.AddDatabaseConnectionConfigurationProviderAction(configuration);

            // Level 2.
            var parameterizedConnectionStringProviderAction = services.AddParameterizedConnectionStringProviderAction(
                databaseConnectionConfigurationProviderAction);
            var parameterlessConnectionStringProviderAction = services.AddParameterlessConnectionStringProviderAction(
                databaseConnectionConfigurationProviderAction);

            return
                (
                databaseConnectionConfigurationProviderAction,
                parameterizedConnectionStringProviderAction,
                parameterlessConnectionStringProviderAction
                );
        }
    }
}
