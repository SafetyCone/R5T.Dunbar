using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.T0022;

using RawDatabaseConfigurationOptions = R5T.Dunbar.T003.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D003.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DatabaseConnectionConfigurationProvider"/> implementation of <see cref="IDatabaseConnectionConfigurationProvider"/> as a <see cref="ServiceLifetime.Singleton"/> from configuation.
        /// </summary>
        public static IServiceCollection AddDatabaseConnectionConfigurationProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<RawDatabaseConfigurationOptions>(configuration.GetSection(ConfigurationSectionNames.Instance.DatabaseConnectionConfiguration()))
                .ConfigureOptions<DatabaseConnectionConfigurationConfigureOptions>()
                .AddSingleton<IDatabaseConnectionConfigurationProvider, DatabaseConnectionConfigurationProvider>()
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DatabaseConnectionConfigurationProvider"/> implementation of <see cref="IDatabaseConnectionConfigurationProvider"/> as a <see cref="ServiceLifetime.Singleton"/> from configuation.
        /// </summary>
        public static IServiceAction<IDatabaseConnectionConfigurationProvider> AddDatabaseConnectionConfigurationProviderAction(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceAction = ServiceAction.New<IDatabaseConnectionConfigurationProvider>(() => services.AddDatabaseConnectionConfigurationProvider(
                configuration));

            return serviceAction;
        }
    }
}
