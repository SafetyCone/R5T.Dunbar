using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;
using R5T.Dunbar.Construction.Operations;

using IDatabaseConnectionConfigurationProvider = R5T.Dunbar.D003.IDatabaseConnectionConfigurationProvider;
using IRawDatabaseConnectionConfigurationProvider = R5T.Dunbar.D002.IDatabaseConnectionConfigurationProvider;

using IParameterlessConnectionStringProvider = R5T.Dunbar.D004.IConnectionStringProvider;
using IParameterizedConnectionStringProvider = R5T.Dunbar.D005.IConnectionStringProvider;


namespace R5T.Dunbar
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GetRawDatabaseConnectionConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetRawDatabaseConnectionConfiguration(this IServiceCollection services,
            IServiceAction<IRawDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            services.AddSingleton<GetRawDatabaseConnectionConfiguration>()
                .Run(databaseConnectionConfigurationProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetRawDatabaseConnectionConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetRawDatabaseConnectionConfiguration> AddGetRawDatabaseConnectionConfigurationAction(this IServiceCollection services,
            IServiceAction<IRawDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            var serviceAction = ServiceAction.New<GetRawDatabaseConnectionConfiguration>(() => services.AddGetRawDatabaseConnectionConfiguration(
                databaseConnectionConfigurationProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="GetDatabaseConnectionConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetDatabaseConnectionConfiguration(this IServiceCollection services,
            IServiceAction<IDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            services.AddSingleton<GetDatabaseConnectionConfiguration>()
                .Run(databaseConnectionConfigurationProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetDatabaseConnectionConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetDatabaseConnectionConfiguration> AddGetDatabaseConnectionConfigurationAction(this IServiceCollection services,
            IServiceAction<IDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            var serviceAction = ServiceAction.New<GetDatabaseConnectionConfiguration>(() => services.AddGetDatabaseConnectionConfiguration(
                databaseConnectionConfigurationProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="GetDatabaseConnectionString"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetDatabaseConnectionString(this IServiceCollection services,
            IServiceAction<IParameterizedConnectionStringProvider> parameterizedConnectionStringProviderAction,
            IServiceAction<IParameterlessConnectionStringProvider> parameterlessConnectionStringProviderAction)
        {
            services.AddSingleton<GetDatabaseConnectionString>()
                .Run(parameterizedConnectionStringProviderAction)
                .Run(parameterlessConnectionStringProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetDatabaseConnectionString"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetDatabaseConnectionString> AddGetDatabaseConnectionStringAction(this IServiceCollection services,
            IServiceAction<IParameterizedConnectionStringProvider> parameterizedConnectionStringProviderAction,
            IServiceAction<IParameterlessConnectionStringProvider> parameterlessConnectionStringProviderAction)
        {
            var serviceAction = ServiceAction.New<GetDatabaseConnectionString>(() => services.AddGetDatabaseConnectionString(
                parameterizedConnectionStringProviderAction,
                parameterlessConnectionStringProviderAction));

            return serviceAction;
        }
    }
}
