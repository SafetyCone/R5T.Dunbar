using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;

using R5T.Dunbar.D004;


namespace R5T.Dunbar.D006.Migrations
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedMigrationsDbContextOptionsBuilderConfigurer{TDbContext}"/> implementation of <see cref="IDbContextOptionsBuilderConfigurer{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedMigrationsDbContextOptionsBuilderConfigurer<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            string migrationsAssemblyName)
            where TDbContext : DbContext
        {
            services
                .AddSingleton<IDbContextOptionsBuilderConfigurer<TDbContext>>(serviceProvider =>
                {
                    var connectionStringProvider = serviceProvider.GetRequiredService<IConnectionStringProvider>();

                    var migrationsDbContextOptionsBuilderConfigurer = new ConstructorBasedMigrationsDbContextOptionsBuilderConfigurer<TDbContext>(
                        connectionStringProvider,
                        migrationsAssemblyName);

                    return migrationsDbContextOptionsBuilderConfigurer;
                })
                .Run(connectionStringProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedMigrationsDbContextOptionsBuilderConfigurer"/> implementation of <see cref="IDbContextOptionsBuilderConfigurer{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> AddConstructorBasedMigrationsDbContextOptionsBuilderConfigurerAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            string migrationsAssemblyName)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextOptionsBuilderConfigurer<TDbContext>>(() => services.AddConstructorBasedMigrationsDbContextOptionsBuilderConfigurer<TDbContext>(
                connectionStringProviderAction,
                migrationsAssemblyName));

            return serviceAction;
        }
    }
}
