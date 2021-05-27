using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D007
{
    public class FunctionBasedDbContextConstructorProvider<TDbContext> : DbContextConstructorProviderBase<TDbContext>
        where TDbContext : DbContext
    {
        private Func<DbContextOptions<TDbContext>, Task<TDbContext>> Constructor { get; }



        public FunctionBasedDbContextConstructorProvider(IDbContextOptionsProvider<TDbContext> dbContextOptionsProvider,
            Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
            : base(dbContextOptionsProvider)
        {
            this.Constructor = constructor;
        }

        protected override Task<TDbContext> ConstructDbContext(DbContextOptions<TDbContext> dbContextOptions)
        {
            return this.Constructor(dbContextOptions);
        }
    }
}
