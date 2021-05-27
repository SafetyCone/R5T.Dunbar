using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.Dunbar.A001.Operations;


namespace R5T.Dunbar.A001
{
    public static class IServiceProviderExtensions
    {
        public static async Task<IServiceProvider> AddDatabaseConnectionConfigurationJsonFilePaths(this Task<IServiceProvider> gettingServiceProvider, IConfigurationBuilder configurationBuilder)
        {
            var serviceProvider = await gettingServiceProvider;

            await serviceProvider.Run<AddDatabaseConnectionConfigurationJsonFilePaths, IConfigurationBuilder>(configurationBuilder);

            return serviceProvider;
        }
    }
}
