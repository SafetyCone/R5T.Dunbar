using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.Dunbar.T007;


namespace R5T.Dunbar.D003
{
    [ServiceDefinitionMarker]
    public interface IDatabaseConnectionConfigurationProvider : IServiceDefinition
    {
        Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration();
    }
}
