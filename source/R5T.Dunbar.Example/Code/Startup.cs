using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar;

using R5T.D0072.Dunbar;

using R5T.Dunbar.D006;
using R5T.Dunbar.D007;

using R5T.Dunbar.A001;

using R5T.Dunbar.Example.Database;
using R5T.Dunbar.Example.Repository;
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
            var databaseConnectionConfigurationActions = services.AddDatabaseConnectionConfigurationActions(configuration);

            // Level 2.
            var dbContextConstructorAction = services.AddDbContextConstructorAction<ExampleDbContext>(
                databaseConnectionConfigurationActions.ParameterlessConnectionStringProviderAction,
                ExampleDbContext.Constructor);
            var dbContextConstructorProviderAction = services.AddDbContextConstructorProviderAction<ExampleDbContext>(
                databaseConnectionConfigurationActions.ParameterizedConnectionStringProviderAction,
                ExampleDbContext.Constructor);

            var exampleRepositoryAction = services.AddExampleRepositoryAction<ExampleDbContext>(
                dbContextConstructorAction.DbContextConstructorAction);

            // Important to use the 
            var exampleRepositoryProviderAction = services.AddFunctionBasedRepositoryProviderAction<IExampleRepository, ExampleDbContext>(
                dbContextConstructorProviderAction.DbContextConstructorProviderAction,
                ExampleRepository<ExampleDbContext>.Constructor);

#pragma warning restore IDE0042 // Deconstruct variable declaration

            // Operations.
            var getExampleRepositoriesFromNamedSourcesAction = services.AddGetExampleRepositoriesFromNamedSourcesAction(
                exampleRepositoryProviderAction);
            var getExampleRepositoryAction = services.AddGetExampleRepositoryAction(
                exampleRepositoryAction);

            services
                .Run(getExampleRepositoriesFromNamedSourcesAction)
                .Run(getExampleRepositoryAction)
                ;
        }
    }
}
