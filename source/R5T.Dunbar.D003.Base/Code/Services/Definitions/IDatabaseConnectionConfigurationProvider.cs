using System;
using System.Threading.Tasks;

using R5T.Dunbar.T007;


namespace R5T.Dunbar.D003
{
    public interface IDatabaseConnectionConfigurationProvider
    {
        Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration();
    }
}
