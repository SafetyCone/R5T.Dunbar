using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SecretsJsonFilePathProvider"/> implementation of <see cref="ISecretsJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSecretsJsonFilePathProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction,
            IServiceAction<ISecretsJsonFileNameProvider> secretsJsonFileNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services.AddSingleton<ISecretsJsonFilePathProvider, SecretsJsonFilePathProvider>()
                .Run(secretsDirectoryPathProviderAction)
                .Run(secretsJsonFileNameProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SecretsJsonFilePathProvider"/> implementation of <see cref="ISecretsJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsJsonFilePathProvider> AddSecretsJsonFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction,
            IServiceAction<ISecretsJsonFileNameProvider> secretsJsonFileNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<ISecretsJsonFilePathProvider>(() => services.AddSecretsJsonFilePathProvider(
                secretsDirectoryPathProviderAction,
                secretsJsonFileNameProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="JsonFilePathProvider"/> implementation of <see cref="IJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddJsonFilePathProvider(this IServiceCollection services,
            IServiceAction<IDirectoryPathProvider> directoryPathProviderAction,
            IServiceAction<IJsonFileNameProvider> jsonFileNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services.AddSingleton<IJsonFilePathProvider, JsonFilePathProvider>()
                .Run(directoryPathProviderAction)
                .Run(jsonFileNameProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="JsonFilePathProvider"/> implementation of <see cref="IJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IJsonFilePathProvider> AddJsonFilePathProviderAction(this IServiceCollection services,
            IServiceAction<IDirectoryPathProvider> directoryPathProviderAction,
            IServiceAction<IJsonFileNameProvider> jsonFileNameProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IJsonFilePathProvider>(() => services.AddJsonFilePathProvider(
                directoryPathProviderAction,
                jsonFileNameProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedSecretsJsonFileNameProvider"/> implementation of <see cref="ISecretsJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedSecretsJsonFileNameProvider(this IServiceCollection services,
            string secretsJsonFileName)
        {
            services.AddSingleton<ISecretsJsonFileNameProvider>(new ConstructorBasedSecretsJsonFileNameProvider(secretsJsonFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedSecretsJsonFileNameProvider"/> implementation of <see cref="ISecretsJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsJsonFileNameProvider> AddConstructorBasedSecretsJsonFileNameProviderAction(this IServiceCollection services,
            string secretsJsonFileName)
        {
            var serviceAction = ServiceAction.New<ISecretsJsonFileNameProvider>(() => services.AddConstructorBasedSecretsJsonFileNameProvider(
                secretsJsonFileName));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedJsonFileNameProvider"/> implementation of <see cref="IJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedJsonFileNameProvider(this IServiceCollection services,
            string jsonFileName)
        {
            services.AddSingleton<IJsonFileNameProvider>(new ConstructorBasedJsonFileNameProvider(jsonFileName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedJsonFileNameProvider"/> implementation of <see cref="IJsonFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IJsonFileNameProvider> AddConstructorBasedJsonFileNameProviderAction(this IServiceCollection services,
            string jsonFileName)
        {
            var serviceAction = ServiceAction.New<IJsonFileNameProvider>(() => services.AddConstructorBasedJsonFileNameProvider(
                jsonFileName));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedJsonFilePathProvider"/> implementation of <see cref="IJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedJsonFilePathProvider(this IServiceCollection services,
            string jsonFilePath)
        {
            services.AddSingleton<IJsonFilePathProvider>(new ConstructorBasedJsonFilePathProvider(jsonFilePath));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedJsonFilePathProvider"/> implementation of <see cref="IJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IJsonFilePathProvider> AddConstructorBasedJsonFilePathProviderAction(this IServiceCollection services,
            string jsonFilePath)
        {
            var serviceAction = ServiceAction.New<IJsonFilePathProvider>(() => services.AddConstructorBasedJsonFilePathProvider(
                jsonFilePath));

            return serviceAction;
        }
    }
}
