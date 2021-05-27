using System;
using System.Data.SqlClient;

using R5T.Dunbar.T005;
using R5T.Dunbar.T006;


namespace System
{
    public static class RemoteDatabaseConnectionStringSpecificationExtensions
    {
        public static ConnectionString GetConnectionString(this RemoteDatabaseConnectionStringSpecification remoteDatabaseConnectionStringSpecification)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = remoteDatabaseConnectionStringSpecification.ServerLocation.Value,
                InitialCatalog = remoteDatabaseConnectionStringSpecification.ServerDatabaseName.Value,
                UserID = remoteDatabaseConnectionStringSpecification.ServerAuthentication.Username,
                Password = remoteDatabaseConnectionStringSpecification.ServerAuthentication.Password,
            };

            var connectionStringValue = connectionStringBuilder.ToString();

            var connectionString = ConnectionString.From(connectionStringValue);
            return connectionString;
        }
    }
}
