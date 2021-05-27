using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D006
{
    public abstract class DbContextConstructorBase<TDbContext> : IDbContextConstructor<TDbContext>
        where TDbContext : DbContext
    {
        private IDbContextOptionsProvider<TDbContext> DbContextOptionsProvider { get; }


        public DbContextConstructorBase(
            IDbContextOptionsProvider<TDbContext> dbContextOptionsProvider)
        {
            this.DbContextOptionsProvider = dbContextOptionsProvider;
        }

        public async Task<TDbContext> GetNewDbContext()
        {
            var dbContextOptions = await this.DbContextOptionsProvider.GetDbContextOptions();

            var dbContext = await this.ConstructDbContext(dbContextOptions);
            return dbContext;
        }

        protected abstract Task<TDbContext> ConstructDbContext(DbContextOptions<TDbContext> dbContextOptions);
    }
}
