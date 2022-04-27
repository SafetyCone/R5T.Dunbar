using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.T0064;


namespace R5T.Dunbar.D007
{
    [ServiceDefinitionMarker]
    public interface IDbContextOptionsProvider<TDbContext> : IServiceImplementation
        where TDbContext : DbContext
    {
        Task<DbContextOptions<TDbContext>> GetDbContextOptions(string databaseName);
    }
}
