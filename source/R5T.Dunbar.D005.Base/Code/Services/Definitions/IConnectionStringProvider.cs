using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.D005
{
    public interface IConnectionStringProvider
    {
        Task<string> GetConnectionString(string databaseName);
    }
}
