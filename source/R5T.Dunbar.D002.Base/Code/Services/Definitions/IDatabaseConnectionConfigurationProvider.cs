using System;
using System.Threading.Tasks;

using R5T.Dunbar.T003;


namespace R5T.Dunbar.D002
{
    public interface IDatabaseConnectionConfigurationProvider
    {
        Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration();
    }
}
