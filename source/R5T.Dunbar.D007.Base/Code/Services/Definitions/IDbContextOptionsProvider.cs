using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D007
{
    public interface IDbContextOptionsProvider<TDbContext>
        where TDbContext : DbContext
    {
        Task<DbContextOptions<TDbContext>> GetDbContextOptions(string databaseName);
    }
}
