using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D006;


namespace R5T.Dunbar.D007
{
    public class DbContextConstructor<TDbContext> : IDbContextConstructor<TDbContext>
        where TDbContext : DbContext
    {
        private Func<DbContextOptions<TDbContext>, Task<TDbContext>> GetDbContext { get; }
        private Func<Task<DbContextOptions<TDbContext>>> GetDbContextOptions { get; }


        public DbContextConstructor(
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> getDbContext,
            Func<Task<DbContextOptions<TDbContext>>> getDbContextOptions)
        {
            this.GetDbContext = getDbContext;
            this.GetDbContextOptions = getDbContextOptions;
        }

        public async Task<TDbContext> GetNewDbContext()
        {
            var dbContextOptions = await this.GetDbContextOptions();

            var dbContext = await this.GetDbContext(dbContextOptions);
            return dbContext;
        }
    }
}
