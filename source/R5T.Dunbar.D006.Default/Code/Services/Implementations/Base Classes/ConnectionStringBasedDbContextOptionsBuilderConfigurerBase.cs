using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D004;


namespace R5T.Dunbar.D006
{
    public abstract class ConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext> : IDbContextOptionsBuilderConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        protected IConnectionStringProvider ConnectionStringProvider { get; }


        public ConnectionStringBasedDbContextOptionsBuilderConfigurerBase(
            IConnectionStringProvider connectionStringProvider)
        {
            this.ConnectionStringProvider = connectionStringProvider;
        }

        public async Task ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder)
        {
            var connectionString = await this.ConnectionStringProvider.GetConnectionString();

            await this.ConfigureDbContextOptionsBuilder_Internal(dbContextOptionsBuilder, connectionString);
        }

        public abstract Task ConfigureDbContextOptionsBuilder_Internal(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, string connectionString);
    }
}
