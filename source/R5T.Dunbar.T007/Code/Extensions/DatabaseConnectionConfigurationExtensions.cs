using System;
using System.Collections.Generic;

using R5T.T0023;

using R5T.Dunbar.T005;
using R5T.Dunbar.T006;
using R5T.Dunbar.T007;


namespace System
{
    public static class DatabaseConnectionConfigurationExtensions
    {
        /// <summary>
        /// Will throw an exception if there is no <see cref="DatabaseConnectionConfiguration.DatabaseName"/> value.
        /// </summary>
        public static DatabaseName GetDatabaseName(this DatabaseConnectionConfiguration databaseConnectionConfiguration)
        {
            if (databaseConnectionConfiguration.DatabaseName is null)
            {
                throw new Exception("No database name was specified in the database connection configuration.");
            }

            return databaseConnectionConfiguration.DatabaseName;
        }

        public static LocalBaseConnectionString GetLocalBaseConnectionString(this DatabaseConnectionConfiguration databaseConnectionConfiguration)
        {
            if (databaseConnectionConfiguration.LocalBaseConnectionString is null)
            {
                throw new Exception("No local base connection string was specified in the database connection configuration.");
            }

            return databaseConnectionConfiguration.LocalBaseConnectionString;
        }

        public static ConnectionConfiguration GetConnectionConfiguration(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            DatabaseName databaseName)
        {
            var namedConnectionConfiguration = databaseConnectionConfiguration.ConnectionConfigurationsByDatabaseName[databaseName];

            var connectionConfiguration = namedConnectionConfiguration.ConnectionConfiguration;
            return connectionConfiguration;
        }

        public static bool HasDirectConnectionStringForDatabaseName(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            DatabaseName databaseName)
        {
            var hasDirectConnectionString = databaseConnectionConfiguration.ConnectionStringsByDatabaseName.ContainsKey(databaseName);
            return hasDirectConnectionString;
        }

        /// <summary>
        /// Gets a <see cref="ConnectionString"/> directly from <see cref="DatabaseConnectionConfiguration.ConnectionStringsByDatabaseName"/>.
        /// </summary>
        public static ConnectionString GetDirectConnectionStringForDatabaseName(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            DatabaseName databaseName)
        {
            var hasDirectConnectionString = databaseConnectionConfiguration.HasDirectConnectionStringForDatabaseName(databaseName);
            if (!hasDirectConnectionString)
            {
                throw new KeyNotFoundException($"No connection string for database name found in database connection configuration connection strings-by-database name.\nDatabase name: {databaseName}.");
            }

            var namedConnectionString = databaseConnectionConfiguration.ConnectionStringsByDatabaseName[databaseName];
            return namedConnectionString.ConnectionString;
        }

        public static ConnectionString GetDirectConnectionStringForDatabaseName(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            string databaseNameValue)
        {
            var databaseName = DatabaseName.From(databaseNameValue);

            var connectionString = databaseConnectionConfiguration.GetDirectConnectionStringForDatabaseName(databaseName);
            return connectionString;
        }

        public static LocalDatabaseConnectionStringSpecification GetLocalDatabaseConnectionStringSpecification(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            ConnectionConfiguration connectionConfiguration)
        {
            var serverDatabaseName = connectionConfiguration.ServerDatabaseName;

            var localBaseConnectionString = databaseConnectionConfiguration.GetLocalBaseConnectionString();

            // Specifification.
            var specification = new LocalDatabaseConnectionStringSpecification
            {
                ServerDatabaseName = serverDatabaseName,
                BaseConnectionString = localBaseConnectionString,
            };

            return specification;
        }

        public static RemoteDatabaseConnectionStringSpecification GetRemoteDatabaseConnectionStringSpecification(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            ConnectionConfiguration connectionConfiguration)
        {
            var serverDatabaseName = connectionConfiguration.ServerDatabaseName;

            var serverConfiguration = databaseConnectionConfiguration.GetServerConfiguration(connectionConfiguration);

            // Location.
            var serverLocationName = serverConfiguration.ServerLocationName;

            var namedServerLocation = databaseConnectionConfiguration.ServerLocationsByServerLocationName[serverLocationName];
            var serverLocation = namedServerLocation.ServerLocation;

            // Authentication.
            var serverAuthenticationName = serverConfiguration.ServerAuthenticationName;

            var namedServerAuthentication = databaseConnectionConfiguration.ServerAuthenticationsByServerAuthenticationName[serverAuthenticationName];
            var serverAuthentication = namedServerAuthentication.ServerAuthentication;

            // Specifification.
            var specification = new RemoteDatabaseConnectionStringSpecification
            {
                ServerDatabaseName = serverDatabaseName,
                ServerLocation = serverLocation,
                ServerAuthentication = serverAuthentication,
            };

            return specification;
        }

        public static ServerConfiguration GetServerConfiguration(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            ConnectionConfiguration connectionConfiguration)
        {
            var serverName = connectionConfiguration.ServerName;

            var namedServerConfiguration = databaseConnectionConfiguration.ServerConfigurationsByServerName[serverName];

            var serverConfiguration = namedServerConfiguration.ServerConfiguration;
            return serverConfiguration;
        }

        public static LocalOrRemote IsConnectionLocalOrRemote(this DatabaseConnectionConfiguration databaseConnectionConfiguration,
            ConnectionConfiguration connectionConfiguration)
        {
            var serverConfiguration = databaseConnectionConfiguration.GetServerConfiguration(connectionConfiguration);

            return serverConfiguration.LocalOrRemote;
        }
    }
}
