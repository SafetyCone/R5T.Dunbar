using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.Dunbar.D002.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DatabaseConnectionConfigurationProvider"/> implementation of <see cref="IDatabaseConnectionConfigurationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDatabaseConnectionConfigurationProvider(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            services.AddSingleton<IDatabaseConnectionConfigurationProvider, DatabaseConnectionConfigurationProvider>()
                .Run(configurationAction);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DatabaseConnectionConfigurationProvider"/> implementation of <see cref="IDatabaseConnectionConfigurationProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDatabaseConnectionConfigurationProvider> AddDatabaseConnectionConfigurationProviderAction(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            var serviceAction = ServiceAction.New<IDatabaseConnectionConfigurationProvider>(() => services.AddDatabaseConnectionConfigurationProvider(
                configurationAction));

            return serviceAction;
        }
    }
}
