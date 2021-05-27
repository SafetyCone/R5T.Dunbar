using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D006
{
    public class FunctionBasedDbContextConstructor<TDbContext> : DbContextConstructorBase<TDbContext>
        where TDbContext : DbContext
    {
        private Func<DbContextOptions<TDbContext>, Task<TDbContext>> Constructor { get; }



        public FunctionBasedDbContextConstructor(IDbContextOptionsProvider<TDbContext> dbContextOptionsProvider,
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
