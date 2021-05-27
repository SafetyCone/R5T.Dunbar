using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using R5T.Dunbar.D004;


namespace R5T.Dunbar.D006
{
    public class SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext> : SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext>
        where TDbContext : DbContext
    {
        public SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        protected override Task ConfigureSqlServerDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder, SqlServerDbContextOptionsBuilder sqlServerDbContextOptionsBuilder)
        {
            // Do nothing.

            return Task.CompletedTask;
        }
    }
}
