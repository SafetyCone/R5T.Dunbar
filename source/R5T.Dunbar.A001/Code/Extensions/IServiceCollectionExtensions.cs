using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Bulgaria;
using R5T.Carpathia;
using R5T.Costobocia;
using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;
using R5T.Quadia;
using R5T.Suebia;
using R5T.Suebia.Standard;
using R5T.Visigothia;

using R5T.D0065;
using R5T.D0065.Standard;
using R5T.D0070;
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
using IOrganizationDirectoryPathProvider = R5T.Carpathia.IOrganizationDirectoryPathProvider;
using IOrganizationalDirectoryPathProvider = R5T.Costobocia.IOrganizationDirectoryPathProvider;
using ISecretsDirectoryPathProvider = R5T.Suebia.ISecretsDirectoryPathProvider;


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


        public static
            (
            (
            IServiceAction<IDirectoryNameOperator> DirectoryNameOperatorAction,
            IServiceAction<IDirectorySeparatorOperator> DirectorySeparatorOperatorAction,
            IServiceAction<IFileExtensionOperator> FileExtensionOperatorAction,
            IServiceAction<IFileNameOperator> FileNameOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> StringlyTypedPathOperatorAction
            ) PathRelatedOperatorsAction,
            (
            IServiceAction<IExecutableDirectoryPathProvider> _,
            IServiceAction<IExecutableFilePathProvider> IExecutableFilePathProviderAction
            ) ExecutableDirectoryPathProviderAction,
            (
            IServiceAction<IAppSettingsFilePathProvider> _,
            IServiceAction<IAppSettingsDirectoryPathProvider> AppSettingsDirectoryPathProviderAction,
            IServiceAction<IAppSettingsFileNameProvider> AppSettingsFileNameProviderAction
            ) DefaultJsonAppSettingsFilePathProviderAction,
            (
            IServiceAction<ISecretsDirectoryFilePathProvider> _,
            IServiceAction<ISecretsDirectoryPathProvider> SecretsDirectoryPathProviderAction,
            IServiceAction<IOrganizationDataDirectoryPathProvider> OrganizationDataDirectoryPathProviderAction,
            IServiceAction<IOrganizationDirectoryPathProvider> OrganizationDirectoryPathProviderAction,
            IServiceAction<ISharedOrganizationDirectoryPathProvider> SharedOrganizationDirectoryPathProviderAction,
            IServiceAction<ISharedDirectoryNameProvider> SharedDirectoryNameProviderAction,
            IServiceAction<IOrganizationalDirectoryPathProvider> OrganizationalDirectoryPathProviderAction,
            IServiceAction<IOrganizationDirectoryNameProvider> OrganizationDirectoryNameProviderAction,
            IServiceAction<IOrganizationsDirectoryPathProvider> OrganizationsDirectoryPathProviderAction,
            IServiceAction<IOrganizationsDirectoryNameProvider> OrganizationsDirectoryNameProviderAction,
            IServiceAction<IDropboxDirectoryPathProvider> DropboxDirectoryPathProviderAction,
            IServiceAction<IDropboxDirectoryNameProvider> DropboxDirectoryNameProviderAction,
            IServiceAction<IUserProfileDirectoryPathProvider> UserProfileDirectoryPathProviderAction
            ) SecretsDirectoryFilePathProviderAction,
            FilePathServicesAggregation02 DatabaseConnectionConfigurationFilePathServicesAggregation,
            IServiceAction<AddDatabaseConnectionConfigurationJsonFilePaths> AddDatabaseConnectionConfigurationJsonFilePathsAction
            )
        AddDefaultConfigurationServiceActions(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration

            // Level 0.
            var pathRelatedOperatorsAction = services.AddPathRelatedOperatorsAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);
            var secretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryFilePathProviderAction(
                organizationProviderAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Level 2.
            var defaultJsonAppSettingsFilePathProviderAction = services.AddDefaultJsonAppSettingsFilePathProviderAction(
                executableDirectoryPathProviderAction._,
                pathRelatedOperatorsAction.FileNameOperatorAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Level 3.
            var databaseConnectionConfigurationFilePathServicesAggregation = services.AddDatabaseConnectionConfigurationFilePathServicesAction(
                defaultJsonAppSettingsFilePathProviderAction.AppSettingsDirectoryPathProviderAction,
                secretsDirectoryFilePathProviderAction._,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Operations.
            var addDatabaseConnectionConfigurationJsonFilePathsAction = services.AddAddDatabaseConnectionConfigurationJsonFilePathsAction(
                databaseConnectionConfigurationFilePathServicesAggregation.JsonFilePathProviderAction,
                databaseConnectionConfigurationFilePathServicesAggregation.SecretsJsonFilePathProviderAction);

#pragma warning restore IDE0042 // Deconstruct variable declaration

            return
                (
                pathRelatedOperatorsAction,
                executableDirectoryPathProviderAction,
                defaultJsonAppSettingsFilePathProviderAction,
                secretsDirectoryFilePathProviderAction,
                databaseConnectionConfigurationFilePathServicesAggregation,
                addDatabaseConnectionConfigurationJsonFilePathsAction
                );
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
