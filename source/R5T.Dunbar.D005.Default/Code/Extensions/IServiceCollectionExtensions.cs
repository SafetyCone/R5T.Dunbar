using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Dunbar.D003;


namespace R5T.Dunbar.D005
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConnectionStringProvider"/> implementation of <see cref="IConnectionStringProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConnectionStringProvider(this IServiceCollection services,
            IServiceAction<IDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>()
                .Run(databaseConnectionConfigurationProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConnectionStringProvider"/> implementation of <see cref="IConnectionStringProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConnectionStringProvider> AddConnectionStringProviderAction(this IServiceCollection services,
            IServiceAction<IDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            var serviceAction = ServiceAction.New<IConnectionStringProvider>(() => services.AddConnectionStringProvider(
                databaseConnectionConfigurationProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConnectionStringProvider"/> implementation of <see cref="IConnectionStringProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConnectionStringProvider> AddParameterizedConnectionStringProviderAction(this IServiceCollection services,
            IServiceAction<IDatabaseConnectionConfigurationProvider> databaseConnectionConfigurationProviderAction)
        {
            return services.AddConnectionStringProviderAction(
                databaseConnectionConfigurationProviderAction);
        }
    }
}
