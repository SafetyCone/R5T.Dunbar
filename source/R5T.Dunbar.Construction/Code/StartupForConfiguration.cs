using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Ostrogothia.Rivet;

using R5T.Dunbar.A001;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.Dunbar.Construction
{
    public class StartupForConfiguration : StartupBase
    {
        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServiceProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServiceProvider);

#pragma warning disable IDE0042 // Deconstruct variable declaration

            // Level 0.
            var organizationProviderAction = services.AddOrganizationProviderAction();

            // Level 1.
            var configurationServiceActions = services.AddDefaultConfigurationServiceActions(
                organizationProviderAction);

#pragma warning restore IDE0042 // Deconstruct variable declaration

            services
                .Run(configurationServiceActions.AddDatabaseConnectionConfigurationJsonFilePathsAction)
                ;
        }
    }
}
