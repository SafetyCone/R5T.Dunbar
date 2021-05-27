using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0070;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;
using R5T.Dunbar.D001.I002.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IAppSettingsDirectoryPathProvider> appSettingsDirectoryPathProviderAction)
        {
            services.AddSingleton<IDirectoryPathProvider, DirectoryPathProvider>()
                .Run(appSettingsDirectoryPathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryPathProvider> AddDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IAppSettingsDirectoryPathProvider> appSettingsDirectoryPathProviderAction)
        {
            var serviceAction = ServiceAction.New<IDirectoryPathProvider>(() => services.AddDirectoryPathProvider(appSettingsDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
