using System;
using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.Example.Repository.DbContext;
using R5T.Dunbar.Example.Repository.Entities;


namespace R5T.Dunbar.Example.Database
{
    public class ExampleDbContext : DbContext, IExampleDbContext
    {
        public DbSet<ExampleEntity> ExampleEntities { get; set; }


        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        {
        }   
    }
}
