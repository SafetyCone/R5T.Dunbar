using System;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;


namespace R5T.Dunbar.D007
{
    public class DbContextConstructorProviderAggregation01<TDbContext>
        where TDbContext : DbContext
    {
        public IServiceAction<IDbContextOptionsBuilderConfigurer<TDbContext>> DbContextOptionBuilderConfigurerAction { get; set; }
        public IServiceAction<IDbContextOptionsProvider<TDbContext>> DbContextOptionsProviderAction { get; set; }
        public IServiceAction<IDbContextConstructorProvider<TDbContext>> DbContextConstructorProviderAction { get; set; }
    }
}
