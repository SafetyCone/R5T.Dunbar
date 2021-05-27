using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D006;


namespace R5T.Dunbar.D007
{
    public abstract class DbContextConstructorProviderBase<TDbContext> : IDbContextConstructorProvider<TDbContext>
        where TDbContext : DbContext
    {
        private IDbContextOptionsProvider<TDbContext> DbContextOptionsProvider { get; }


        public DbContextConstructorProviderBase(
            IDbContextOptionsProvider<TDbContext> dbContextOptionsProvider)
        {
            this.DbContextOptionsProvider = dbContextOptionsProvider;
        }

        public Task<IDbContextConstructor<TDbContext>> GetDbContextConstructor(string databaseName)
        {
            var dbContextConstructor = new DbContextConstructor<TDbContext>(
                this.ConstructDbContext,
                () => this.DbContextOptionsProvider.GetDbContextOptions(databaseName));

            return Task.FromResult(dbContextConstructor as IDbContextConstructor<TDbContext>);
        }

        protected abstract Task<TDbContext> ConstructDbContext(DbContextOptions<TDbContext> dbContextOptions);
    }
}
