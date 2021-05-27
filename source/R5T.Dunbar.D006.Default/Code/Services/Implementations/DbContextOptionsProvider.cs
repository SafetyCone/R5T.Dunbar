using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D006
{
    public class DbContextOptionsProvider<TDbContext> : IDbContextOptionsProvider<TDbContext>
        where TDbContext : DbContext
    {
        private IDbContextOptionsBuilderConfigurer<TDbContext> DbContextOptionsBuilderConfigurer { get; }


        public DbContextOptionsProvider(
            IDbContextOptionsBuilderConfigurer<TDbContext> dbContextOptionsBuilderConfigurer)
        {
            this.DbContextOptionsBuilderConfigurer = dbContextOptionsBuilderConfigurer;
        }

        public async Task<DbContextOptions<TDbContext>> GetDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            await this.DbContextOptionsBuilderConfigurer.ConfigureDbContextOptionsBuilder(dbContextOptionsBuilder);

            var dbContextOptions = dbContextOptionsBuilder.Options;
            return dbContextOptions;
        }
    }
}
