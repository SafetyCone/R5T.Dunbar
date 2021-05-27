using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;
using R5T.Dunbar.D001.I003.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I003
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SecretsJsonFilePathProvider"/> implementation of <see cref="ISecretsJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSecretsJsonFilePathProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<ISecretsJsonFileNameProvider> secretsJsonFileNameProviderAction)
        {
            services.AddSingleton<ISecretsJsonFilePathProvider, SecretsJsonFilePathProvider>()
                .Run(secretsDirectoryFilePathProviderAction)
                .Run(secretsJsonFileNameProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SecretsJsonFilePathProvider"/> implementation of <see cref="ISecretsJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsJsonFilePathProvider> AddSecretsJsonFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<ISecretsJsonFileNameProvider> secretsJsonFileNameProviderAction)
        {
            var serviceAction = ServiceAction.New<ISecretsJsonFilePathProvider>(() => services.AddSecretsJsonFilePathProvider(
                secretsDirectoryFilePathProviderAction,
                secretsJsonFileNameProviderAction));

            return serviceAction;
        }
    }
}
