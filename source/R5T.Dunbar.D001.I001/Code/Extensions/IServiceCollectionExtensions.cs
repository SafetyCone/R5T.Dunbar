using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;
using R5T.Dunbar.D001.I001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DefaultSecretsJsonFileNameProvider"/> implementation of <see cref="ISecretsJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultSecretsJsonFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<ISecretsJsonFileNameProvider, DefaultSecretsJsonFileNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DefaultSecretsJsonFileNameProvider"/> implementation of <see cref="ISecretsJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsJsonFileNameProvider> AddDefaultSecretsJsonFileNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<ISecretsJsonFileNameProvider>(() => services.AddDefaultSecretsJsonFileNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DefaultJsonFileNameProvider"/> implementation of <see cref="IJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultJsonFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<IJsonFileNameProvider, DefaultJsonFileNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DefaultJsonFileNameProvider"/> implementation of <see cref="IJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IJsonFileNameProvider> AddDefaultJsonFileNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IJsonFileNameProvider>(() => services.AddDefaultJsonFileNameProvider());
            return serviceAction;
        }
    }
}
