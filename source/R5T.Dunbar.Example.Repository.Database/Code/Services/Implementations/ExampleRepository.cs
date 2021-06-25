using System;
using System.Threading.Tasks;

using R5T.Dunbar.Repository;

using R5T.Dunbar.D006;

using R5T.Dunbar.Example.Repository.DbContext;

using EFDbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace R5T.Dunbar.Example.Repository.Database
{
    public class ExampleRepository<TDbContext> : DbContextBasedRepositoryBase<TDbContext>, IExampleRepository
        where TDbContext : EFDbContext, IExampleDbContext
    {
        #region Static

        public static ExampleRepository<TDbContext> Constructor(
            IDbContextConstructor<TDbContext> dbContextConstructor)
        {
            var output = new ExampleRepository<TDbContext>(dbContextConstructor);
            return output;
        }

        #endregion


        public ExampleRepository(IDbContextConstructor<TDbContext> dbContextConstructor)
            : base(dbContextConstructor)
        {
        }

        public Task<Guid> Add(string value)
        {
            return this.ExecuteInContext(async dbContext =>
            {
                var exampleEntityIdentity = Guid.NewGuid();

                var exampleEntity = new Entities.ExampleEntity
                {
                    Identity = exampleEntityIdentity,
                    Value = value
                };

                dbContext.Add(exampleEntity);

                await dbContext.SaveChangesAsync();

                return exampleEntityIdentity;
            });
        }
    }
}
