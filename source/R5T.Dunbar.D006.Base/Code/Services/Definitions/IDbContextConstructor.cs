using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dunbar.D006
{
    public interface IDbContextConstructor<TDbContext>
        where TDbContext : DbContext
    {
        Task<TDbContext> GetNewDbContext();
    }
}
