using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Dunbar.D006;


namespace R5T.Dunbar.D007
{
    public interface IDbContextConstructorProvider<TDbContext>
        where TDbContext : DbContext
    {
        Task<IDbContextConstructor<TDbContext>> GetDbContextConstructor(string databaseName);
    }
}
