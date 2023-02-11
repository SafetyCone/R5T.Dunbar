using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar.Extensions;

using R5T.Dunbar.A001;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.Dunbar.Construction
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

            // Level 0.

            // Level 1.
            var addDatabaseConnectionConfigurationActions = services.AddDatabaseConnectionConfigurationActions(configuration);
            //var rawDatabaseConnectionConfigurationProviderAction = services.AddDatabaseConnectionConfigurationProviderAction(
            //    configurationAction);


            // Operations.
            var getDatabaseConnectionConfigurationAction = services.AddGetDatabaseConnectionConfigurationAction(
                addDatabaseConnectionConfigurationActions.DatabaseConnectionConfigurationProviderAction);
            //var getRawDatabaseConnectionConfigurationAction = services.AddGetRawDatabaseConnectionConfigurationAction(
            //    rawDatabaseConnectionConfigurationProviderAction);
            var getDatabaseConnectionStringAction = services.AddGetDatabaseConnectionStringAction(
                addDatabaseConnectionConfigurationActions.ParameterizedConnectionStringProviderAction,
                addDatabaseConnectionConfigurationActions.ParameterlessConnectionStringProviderAction);

            services
                //.Run(getRawDatabaseConnectionConfigurationAction)
                .Run(getDatabaseConnectionConfigurationAction)
                .Run(getDatabaseConnectionStringAction)
                ;
        }
    }
}
