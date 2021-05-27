using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar;

using R5T.Dunbar.D006;
using R5T.Dunbar.D006.Migrations;

using R5T.Dunbar.A001;

using R5T.Dunbar.Example.Database;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.Dunbar.Example.Migrations
{
    public class Startup : StartupBase
    {
        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServiceProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServiceProvider);

            await startupServiceProvider.AsTask()
                .AddDatabaseConnectionConfigurationJsonFilePaths(configurationBuilder)
                ;
        }

        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServiceProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServiceProvider);

            var intermediateServiceProvider = services.BuildIntermediateServiceProvider();

            var configuration = intermediateServiceProvider.GetRequiredService<IConfiguration>();

#pragma warning disable IDE0042 // Deconstruct variable declaration

            // Level 1.
            var addDatabaseConnectionConfigurationActions = services.AddDatabaseConnectionConfigurationActions(configuration);

            var dbContextOptionsBuilderConfigurerAction = services.AddConstructorBasedMigrationsDbContextOptionsBuilderConfigurerAction<ExampleDbContext>(
                addDatabaseConnectionConfigurationActions.ParameterlessConnectionStringProviderAction,
                "R5T.Dunbar.Example.Migrations");

            var dbContextConstructorAction = services.AddDbContextConstructorAction<ExampleDbContext>(
                dbContextOptionsBuilderConfigurerAction,
                dbContextOptions => new ExampleDbContext(dbContextOptions));

#pragma warning restore IDE0042 // Deconstruct variable declaration

            services
                .Run(dbContextConstructorAction._)
                ;
        }
    }
}
