﻿using System;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;


namespace R5T.Dunbar.D006
{
    public class DbContextConstructorAggregation02<TDbContext>
        where TDbContext : DbContext
    {
        public IServiceAction<IDbContextConstructor<TDbContext>> DbContextConstructorAction { get; set; }
        public IServiceAction<IDbContextOptionsProvider<TDbContext>> DbContextOptionsProviderAction { get; set; }
    }
}
