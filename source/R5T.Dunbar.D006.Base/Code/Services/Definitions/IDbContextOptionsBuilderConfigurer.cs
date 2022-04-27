using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.T0064;


namespace R5T.Dunbar.D006
{
    [ServiceDefinitionMarker]
    public interface IDbContextOptionsBuilderConfigurer<TDbContext> : IServiceDefinition
        where TDbContext : DbContext
    {
        Task ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder);
    }
}
