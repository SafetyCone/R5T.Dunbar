using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using R5T.T0064;

using R5T.Dunbar.D005;


namespace R5T.Dunbar.D007
{
    [ServiceImplementationMarker]
    public class SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer<TDbContext> : SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext>,
        IDbContextOptionsBuilderConfigurer<TDbContext>,
        IServiceImplementation
        where TDbContext : DbContext
    {
        public SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurer(
            IConnectionStringProvider connectionStringProvider)
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
