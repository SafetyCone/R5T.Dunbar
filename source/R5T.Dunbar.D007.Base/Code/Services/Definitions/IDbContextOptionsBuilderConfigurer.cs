using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D007
{
    public interface IDbContextOptionsBuilderConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        Task ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, string databaseName);
    }
}
