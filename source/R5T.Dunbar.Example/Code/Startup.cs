using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar;

using R5T.Dunbar.D006;

using R5T.Dunbar.A001;

using R5T.Dunbar.Example.Database;
using R5T.Dunbar.Example.Repository.Database;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.Dunbar.Example
{
    class Startup : StartupBase
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

            // Level 0.

            // Level 1.
            var addDatabaseConnectionConfigurationActions = services.AddDatabaseConnectionConfigurationActions(configuration);

            // Level 2.
            var dbContextConstructorAction = services.AddDbContextConstructorAction<ExampleDbContext>(
                addDatabaseConnectionConfigurationActions.ParameterlessConnectionStringProviderAction,
                dbContextOptions => new ExampleDbContext(dbContextOptions));

            var exampleRepositoryAction = services.AddExampleRepositoryAction<ExampleDbContext>(
                dbContextConstructorAction._);

#pragma warning restore IDE0042 // Deconstruct variable declaration

            // Operations.
            var getExampleRepositoryAction = services.AddGetExampleRepositoryAction(
                exampleRepositoryAction);

            services
                .Run(getExampleRepositoryAction)
                ;
        }
    }
}
