using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    [ServiceDefinitionMarker]
    public interface ISecretsJsonFileNameProvider : IServiceDefinition
    {
        Task<string> GetSecretsJsonFileName();
    }
}
