using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D005;


namespace R5T.Dunbar.D007
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

        public async Task ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, string databaseName)
        {
            var connectionString = await this.ConnectionStringProvider.GetConnectionString(databaseName);

            await this.ConfigureDbContextOptionsBuilder_Internal(dbContextOptionsBuilder, connectionString);
        }

        public abstract Task ConfigureDbContextOptionsBuilder_Internal(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, string connectionString);
    }
}
