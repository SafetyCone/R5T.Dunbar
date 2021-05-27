using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.D004
{
    public interface IConnectionStringProvider
    {
        Task<string> GetConnectionString();
    }
}
