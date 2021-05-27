using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Dunbar.Example.Operations;
using R5T.Dunbar.Example.Repository;


namespace R5T.Dunbar.Example
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GetExampleRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetExampleRepository(this IServiceCollection services,
            IServiceAction<IExampleRepository> exampleRepositoryAction)
        {
            services.AddSingleton<GetExampleRepository>()
                .Run(exampleRepositoryAction);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetExampleRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetExampleRepository> AddGetExampleRepositoryAction(this IServiceCollection services,
            IServiceAction<IExampleRepository> exampleRepositoryAction)
        {
            var serviceAction = ServiceAction.New<GetExampleRepository>(() => services.AddGetExampleRepository(
                exampleRepositoryAction));

            return serviceAction;
        }
    }
}
