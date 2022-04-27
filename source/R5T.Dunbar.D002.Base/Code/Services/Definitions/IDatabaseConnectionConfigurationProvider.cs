using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.Dunbar.T003;


namespace R5T.Dunbar.D002
{
    [ServiceDefinitionMarker]
    public interface IDatabaseConnectionConfigurationProvider : IServiceDefinition
    {
        Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration();
    }
}
