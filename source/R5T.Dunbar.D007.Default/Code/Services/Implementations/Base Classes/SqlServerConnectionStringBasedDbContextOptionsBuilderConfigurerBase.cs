using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using R5T.Dunbar.D005;


namespace R5T.Dunbar.D007
{
    public abstract class SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext> : ConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext>,
        IDbContextOptionsBuilderConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        public SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerBase(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        public override Task ConfigureDbContextOptionsBuilder_Internal(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, string connectionString)
        {
            dbContextOptionsBuilder.UseSqlServer(
                connectionString,
                sqlServerDbContextOptionsBuilder =>
                {
                    this.ConfigureSqlServerDbContextOptionsBuilder(dbContextOptionsBuilder, sqlServerDbContextOptionsBuilder).Wait(); // Sync-over-async, bad, but method is synchronous so have to.
                });

            return Task.CompletedTask;
        }

        protected abstract Task ConfigureSqlServerDbContextOptionsBuilder(
            DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder,
            SqlServerDbContextOptionsBuilder sqlServerDbContextOptionsBuilder);
    }
}
