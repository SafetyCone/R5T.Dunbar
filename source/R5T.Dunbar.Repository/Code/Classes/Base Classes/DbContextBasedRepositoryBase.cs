using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D006;


namespace R5T.Dunbar.Repository
{
    public abstract class DbContextBasedRepositoryBase<TDbContext>
        where TDbContext : DbContext
    {
        protected IDbContextConstructor<TDbContext> DbContextConstructor { get; }


        public DbContextBasedRepositoryBase(
            IDbContextConstructor<TDbContext> dbContextConstructor)
        {
            this.DbContextConstructor = dbContextConstructor;
        }

        protected async Task ExecuteInContext(Func<TDbContext, Task> action)
        {
            using var dbContext = await this.DbContextConstructor.GetNewDbContext();

            await action(dbContext); // Await, not return, task since we do not want to exit the using context and thus dispose of the newly created DbContext.
        }

        protected async Task<TOutput> ExecuteInContext<TOutput>(Func<TDbContext, Task<TOutput>> function)
        {
            using var dbContext = await this.DbContextConstructor.GetNewDbContext();

            var output = await function(dbContext); // Await, not return, task since we do not want to exit the using context and thus dispose of the newly created DbContext.
            return output;
        }
    }
}
