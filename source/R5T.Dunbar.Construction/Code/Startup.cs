using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.Dunbar.Construction
{
    public class Startup : StartupBase
    {
        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServiceProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServiceProvider);


        }
    }
}
