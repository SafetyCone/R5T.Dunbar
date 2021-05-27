using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Dunbar.D006;

using R5T.Dunbar.Example.Repository.DbContext;

using EFDbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace R5T.Dunbar.Example.Repository.Database
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExampleRepository{TDbContext}"/> implementation of <see cref="IExampleRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExampleRepository<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextConstructor<TDbContext>> dbContextConstructorAction)
            where TDbContext : EFDbContext, IExampleDbContext
        {
            services.AddSingleton<IExampleRepository, ExampleRepository<TDbContext>>()
                .Run(dbContextConstructorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExampleRepository{TDbContext}"/> implementation of <see cref="IExampleRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExampleRepository> AddExampleRepositoryAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextConstructor<TDbContext>> dbContextConstructorAction)
            where TDbContext : EFDbContext, IExampleDbContext
        {
            var serviceAction = ServiceAction.New<IExampleRepository>(() => services.AddExampleRepository<TDbContext>(
                dbContextConstructorAction));

            return serviceAction;
        }
    }
}
