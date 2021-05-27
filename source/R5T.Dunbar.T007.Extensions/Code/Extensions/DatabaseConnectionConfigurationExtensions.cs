using System;

using R5T.Dunbar.T005;
using R5T.Dunbar.T007;


namespace System
{
    public static class DatabaseConnectionConfigurationExtensions
    {
        public static ConnectionString GetIndirectConnectionString(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            DatabaseName databaseName)
        {
            var connectionConfiguration = databaseConnectionConfiguration.GetConnectionConfiguration(databaseName);

            var localOrRemote = databaseConnectionConfiguration.IsConnectionLocalOrRemote(connectionConfiguration);

            var connectionString = localOrRemote.Switch(
                () =>
                {
                    var localConnectionSpecification = databaseConnectionConfiguration.GetLocalDatabaseConnectionStringSpecification(connectionConfiguration);

                    var localConnectionString = localConnectionSpecification.GetConnectionString();
                    return localConnectionString;
                },
                () =>
                {
                    var remoteConnectionSpecification = databaseConnectionConfiguration.GetRemoteDatabaseConnectionStringSpecification(connectionConfiguration);

                    var remoteConnectionString = remoteConnectionSpecification.GetConnectionString();
                    return remoteConnectionString;
                });

            return connectionString;
        }

        public static ConnectionString GetConnectionString(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            DatabaseName databaseName)
        {
            // If there is a direct connection string, use it.
            var hasDirectConnectionString = databaseConnectionConfiguration.HasDirectConnectionStringForDatabaseName(databaseName);
            if(hasDirectConnectionString)
            {
                var directConnectionString = databaseConnectionConfiguration.GetDirectConnectionStringForDatabaseName(databaseName);
                return directConnectionString;
            }

            // Else, get indirect connection string.
            var indirectConnectionString = databaseConnectionConfiguration.GetIndirectConnectionString(databaseName);
            return indirectConnectionString;
        }

        public static ConnectionString GetConnectionString(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            string databaseNameValue)
        {
            var databaseName = DatabaseName.From(databaseNameValue);

            var connectionString = databaseConnectionConfiguration.GetConnectionString(databaseName);
            return connectionString;
        }

        /// <summary>
        /// Use the <see cref="DatabaseConnectionConfiguration.DatabaseName"/> if no database name is specified.
        /// </summary>
        public static ConnectionString GetConnectionString(this DatabaseConnectionConfiguration databaseConnectionConfiguration)
        {
            var databaseName = databaseConnectionConfiguration.GetDatabaseName();

            var connectionString = databaseConnectionConfiguration.GetConnectionString(databaseName);
            return connectionString;
        }
    }
}
