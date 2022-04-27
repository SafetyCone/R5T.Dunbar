using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.D005
{
    [ServiceDefinitionMarker]
    public interface IConnectionStringProvider : IServiceDefinition
    {
        Task<string> GetConnectionString(string databaseName);
    }
}
