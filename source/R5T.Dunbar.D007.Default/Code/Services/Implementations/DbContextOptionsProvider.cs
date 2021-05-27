using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D007
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

        public async Task<DbContextOptions<TDbContext>> GetDbContextOptions(string databaseName)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            await this.DbContextOptionsBuilderConfigurer.ConfigureDbContextOptionsBuilder(dbContextOptionsBuilder, databaseName);

            var dbContextOptions = dbContextOptionsBuilder.Options;
            return dbContextOptions;
        }
    }
}
