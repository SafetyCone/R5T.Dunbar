using System;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.Example.Repository.Entities;


namespace R5T.Dunbar.Example.Repository.DbContext
{
    public interface IExampleDbContext
    {
        DbSet<ExampleEntity> ExampleEntities { get; }
    }
}
