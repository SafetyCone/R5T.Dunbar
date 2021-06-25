using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;
using R5T.Magyar;

using R5T.Dunbar.D004;


namespace R5T.Dunbar.D006
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
        public static IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> AddSqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextOptionsBuilderConfigurer<TDbContext>>(() => services.AddSqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext>(
                connectionStringProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FunctionBasedDbContextConstructor{TDbContext}"/> implementation of <see cref="IDbContextConstructor{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFunctionBasedDbContextConstructor<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsProvider<TDbContext>> dbContextOptionsProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            services
                .AddSingleton<IDbContextConstructor<TDbContext>>(serviceProvider =>
                {
                    var dbContextOptionsProvider = serviceProvider.GetRequiredService<IDbContextOptionsProvider<TDbContext>>();

                    var dbContextConstructor = new FunctionBasedDbContextConstructor<TDbContext>(
                        dbContextOptionsProvider,
                        constructor);

                    return dbContextConstructor;
                })
                .Run(dbContextOptionsProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FunctionBasedDbContextConstructor{TDbContext}"/> implementation of <see cref="IDbContextConstructor{TDbContext}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDbContextConstructor<TDbContext>> AddFunctionBasedDbContextConstructorAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsProvider<TDbContext>> dbContextOptionsProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var serviceAction = ServiceAction.New<IDbContextConstructor<TDbContext>>(() => services.AddFunctionBasedDbContextConstructor<TDbContext>(
                dbContextOptionsProviderAction,
                constructor));

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

        public static DbContextConstructorAggregation01<TDbContext> AddDbContextConstructorAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var dbContextOptionsBuilderConfigurerAction = services.AddSqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerAction<TDbContext>(
                connectionStringProviderAction);

            var dbContextOptionsProviderAction = services.AddDbContextOptionsProviderAction<TDbContext>(
                dbContextOptionsBuilderConfigurerAction);

            var dbContextConstructorAction = services.AddFunctionBasedDbContextConstructorAction<TDbContext>(
                dbContextOptionsProviderAction,
                constructor);

            return new DbContextConstructorAggregation01<TDbContext>
            {
                DbContextConstructorAction = dbContextConstructorAction,
                DbContextOptionsBuilderConfigurerAction = dbContextOptionsBuilderConfigurerAction,
                DbContextOptionsProviderAction = dbContextOptionsProviderAction,
            };
        }

        public static DbContextConstructorAggregation01<TDbContext> AddDbContextConstructorAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IConnectionStringProvider> connectionStringProviderAction,
            Func<DbContextOptions<TDbContext>, TDbContext> constructor)
            where TDbContext : DbContext
        {
            return services.AddDbContextConstructorAction(
                connectionStringProviderAction,
                TaskHelper.MakeAsynchronous(constructor));
        }

        public static DbContextConstructorAggregation02<TDbContext> AddDbContextConstructorAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            where TDbContext : DbContext
        {
            var dbContextOptionsProviderAction = services.AddDbContextOptionsProviderAction<TDbContext>(
                dbContextOptionsBuilderConfigurerAction);

            var dbContextConstructorAction = services.AddFunctionBasedDbContextConstructorAction<TDbContext>(
                dbContextOptionsProviderAction,
                constructor);

            return new DbContextConstructorAggregation02<TDbContext>
            {
                DbContextConstructorAction = dbContextConstructorAction,
                DbContextOptionsProviderAction = dbContextOptionsProviderAction,
            };
        }

        public static DbContextConstructorAggregation02<TDbContext> AddDbContextConstructorAction<TDbContext>(this IServiceCollection services,
            IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> dbContextOptionsBuilderConfigurerAction,
            Func<DbContextOptions<TDbContext>, TDbContext> constructor)
            where TDbContext : DbContext
        {
            return services.AddDbContextConstructorAction(
                dbContextOptionsBuilderConfigurerAction,
                TaskHelper.MakeAsynchronous(constructor));
        }
    }
}
