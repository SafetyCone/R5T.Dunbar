using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.T0064;

using R5T.Dunbar.D006;


namespace R5T.Dunbar.D007
{
    [ServiceDefinitionMarker]
    public interface IDbContextConstructorProvider<TDbContext> : IServiceDefinition
        where TDbContext : DbContext
    {
        Task<IDbContextConstructor<TDbContext>> GetDbContextConstructor(string databaseName);
    }
}
