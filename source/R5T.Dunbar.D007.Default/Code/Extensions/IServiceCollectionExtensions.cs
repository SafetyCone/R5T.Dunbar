using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;

using R5T.Dunbar.D005;


namespace R5T.Dunbar.D007
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer{TDbContext}"/> implementation of <see cref="IDbContextOptionsBuilderConfigurer{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction)
            where TDbContext : DbContext
        {
            services.AddSingleton<IDbContextOptionsBuilderConfigurer<TDbContext>, SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext>>()
                .Run(connectionStringProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer{TDbContext}"/> implementation of <see cref="IDbContextOptionsBuilderConfigurer{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> AddSqlServerConnectionStringBasedDbContextOptionBuilderConfigurerAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextOptionsBuilderConfigurer<TDbContext>>(() => services.AddSqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext>(
                connectionStringProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DbContextOptionsProvider{TDbContext}"/> implementation of <see cref="IDbContextOptionsProvider{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDbContextOptionsProvider<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction)
            where TDbContext : DbContext
        {
            services.AddSingleton<IDbContextOptionsProvider<TDbContext>, DbContextOptionsProvider<TDbContext>>()
                .Run(dbContextOptionsBuilderConfigurerAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DbContextOptionsProvider{TDbContext}"/> implementation of <see cref="IDbContextOptionsProvider{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDbContextOptionsProvider<TDbContext>> AddDbContextOptionsProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextOptionsProvider<TDbContext>>(() => services.AddDbContextOptionsProvider<TDbContext>(
                dbContextOptionsBuilderConfigurerAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FunctionBasedDbContextConstructorProvider{TDbContext}"/> implementation of <see cref="IDbContextConstructorProvider{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFunctionBasedDbContextConstructorProvider<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsProvider<TDbContext>> dbContextOptionsProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            services
                .AddSingleton<IDbContextConstructorProvider<TDbContext>>(serviceProvider =>
                {
                    var dbContextOptionsProvider = serviceProvider.GetRequiredService<IDbContextOptionsProvider<TDbContext>>();

                    var dbContextConstructorProvider = new FunctionBasedDbContextConstructorProvider<TDbContext>(
                        dbContextOptionsProvider,
                        constructor);

                    return dbContextConstructorProvider;
                })
                .Run(dbContextOptionsProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FunctionBasedDbContextConstructorProvider{TDbContext}"/> implementation of <see cref="IDbContextConstructorProvider{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDbContextConstructorProvider<TDbContext>> AddFunctionBasedDbContextConstructorProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsProvider<TDbContext>> dbContextOptionsProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextConstructorProvider<TDbContext>>(() => services.AddFunctionBasedDbContextConstructorProvider<TDbContext>(
                dbContextOptionsProviderAction,
                constructor));

            return serviceAction;
        }


        public static DbContextConstructorProviderAggregation01<TDbContext> AddDbContextConstructorProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var dbContextOptionsBuilderConfigurerAction = services.AddSqlServerConnectionStringBasedDbContextOptionBuilderConfigurerAction<TDbContext>(
                connectionStringProviderAction);

            var dbContextOptionsProviderAction = services.AddDbContextOptionsProviderAction<TDbContext>(
                dbContextOptionsBuilderConfigurerAction);

            var dbContextConstructorProviderAction = services.AddFunctionBasedDbContextConstructorProviderAction<TDbContext>(
                dbContextOptionsProviderAction,
                constructor);

            return new DbContextConstructorProviderAggregation01<TDbContext>
            {
                DbContextConstructorProviderAction = dbContextConstructorProviderAction,
                DbContextOptionBuilderConfigurerAction = dbContextOptionsBuilderConfigurerAction,
                DbContextOptionsProviderAction = dbContextOptionsProviderAction,
            };
        }

        public static DbContextConstructorProviderAggregation01<TDbContext> AddDbContextConstructorProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            Func<DbContextOptions<TDbContext>, TDbContext> constructor)
            where TDbContext : DbContext
        {
            return services.AddDbContextConstructorProviderAction(
                connectionStringProviderAction,
                DbContextHelper.GetAsynchronousConstructor<TDbContext>(constructor));
        }

        public static DbContextConstructorProviderAggregation02<TDbContext> AddDbContextConstructorProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var dbContextOptionsProviderAction = services.AddDbContextOptionsProviderAction<TDbContext>(
                dbContextOptionsBuilderConfigurerAction);

            var dbContextConstructorProviderAction = services.AddFunctionBasedDbContextConstructorProviderAction<TDbContext>(
                dbContextOptionsProviderAction,
                constructor);

            return new DbContextConstructorProviderAggregation02<TDbContext>
            {
                DbContextConstructorProviderAction = dbContextConstructorProviderAction,
                DbContextOptionsProviderAction = dbContextOptionsProviderAction,
            };
        }

        public static DbContextConstructorProviderAggregation02<TDbContext> AddDbContextConstructorProviderAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction,
            Func<DbContextOptions<TDbContext>, TDbContext> constructor)
            where TDbContext : DbContext
        {
            return services.AddDbContextConstructorProviderAction(
                dbContextOptionsBuilderConfigurerAction,
                DbContextHelper.GetAsynchronousConstructor<TDbContext>(constructor));
        }
    }
}
