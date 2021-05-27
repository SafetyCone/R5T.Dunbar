using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using R5T.Dunbar.D004;


namespace R5T.Dunbar.D006.Migrations
{
    public class ConstructorBasedMigrationsDbContextOptionsBuilderConfigurer<TDbContext>
        : SqlServerConnectionStringBasedDbContextOptionsBuilderConfigurerBase<TDbContext>
        where TDbContext : DbContext
    {
        private string MigrationsAssemblyName { get; }


        public ConstructorBasedMigrationsDbContextOptionsBuilderConfigurer(
            IConnectionStringProvider connectionStringProvider,
            string migrationsAssemblyName)
            : base(connectionStringProvider)
        {
            this.MigrationsAssemblyName = migrationsAssemblyName;
        }

        protected override Task ConfigureSqlServerDbContextOptionsBuilder(
            DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder,
            SqlServerDbContextOptionsBuilder sqlServerDbContextOptionsBuilder)
        {
            sqlServerDbContextOptionsBuilder.MigrationsAssembly(this.MigrationsAssemblyName);

            return Task.CompletedTask;
        }
    }
}
