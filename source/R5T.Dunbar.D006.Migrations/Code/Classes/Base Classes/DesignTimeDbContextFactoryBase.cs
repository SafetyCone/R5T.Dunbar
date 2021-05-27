using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using R5T.Plymouth;
using R5T.Plymouth.Startup;


namespace R5T.Dunbar.D006.Migrations
{
    /// <summary>
    /// An <see cref="IDbContextConstructor{TDbContext}"/> service-based design-time DbContext factory configured using an <see cref="IStartup"/> class.
    /// </summary>
    public abstract class DesignTimeDbContextFactoryBase<TDbContext, TStartup, TStartupForConfiguration> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
        where TStartup : class, IStartup
        where TStartupForConfiguration : class, IStartup
    {
        public TDbContext CreateDbContext(string[] args)
        {
            using var serviceProvider = ApplicationBuilder.Instance
                .NewApplication()
                .UseStartup<TStartup, TStartupForConfiguration>()
                .BuildServiceProvider()
                .Result; // Bad, sync-over-async. But DesignTimeDbContextFactoryBase is synchronous so can't be helped.

            var dbContextConstructor = serviceProvider.GetRequiredService<IDbContextConstructor<TDbContext>>();

            var dbContext = dbContextConstructor.GetNewDbContext().Result;
            return dbContext;
        }
    }
}
