using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.T0064;


namespace R5T.Dunbar.D006
{
    [ServiceImplementationMarker]
    public class FunctionBasedDbContextConstructor<TDbContext> : DbContextConstructorBase<TDbContext>, IDbContextConstructor<TDbContext>, IServiceImplementation
        where TDbContext : DbContext
    {
        private Func<DbContextOptions<TDbContext>, Task<TDbContext>> Constructor { get; }


        public FunctionBasedDbContextConstructor(
            IDbContextOptionsProvider<TDbContext> dbContextOptionsProvider,
            [NotServiceComponent] Func<DbContextOptions<TDbContext>, Task<TDbContext>> constructor)
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
