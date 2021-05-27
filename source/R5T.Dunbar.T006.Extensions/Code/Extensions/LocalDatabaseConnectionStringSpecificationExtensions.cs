using System;
using System.Data.SqlClient;

using R5T.Dunbar.T005;
using R5T.Dunbar.T006;


namespace System
{
    public static class LocalDatabaseConnectionStringSpecificationExtensions
    {
        public static ConnectionString GetConnectionString(this LocalDatabaseConnectionStringSpecification localDatabaseConnectionStringSpecification)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(localDatabaseConnectionStringSpecification.BaseConnectionString.Value)
            {
                InitialCatalog = localDatabaseConnectionStringSpecification.ServerDatabaseName.Value,
            };

            var connectionStringValue = connectionStringBuilder.ToString();

            var connectionString = ConnectionString.From(connectionStringValue);
            return connectionString;
        }
    }
}
