using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Dunbar.Example.Repository
{
    [ServiceDefinitionMarker]
    public interface IExampleRepository : IServiceDefinition
    {
        Task<Guid> Add(string value);
    }
}
