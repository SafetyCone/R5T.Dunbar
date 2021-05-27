using System;

using R5T.Dunbar.T005;
using R5T.Dunbar.T006;

using ConnectionConfiguration = R5T.Dunbar.T002.ConnectionConfiguration;
using StronglyTypedConnectionConfiguration = R5T.Dunbar.T006.ConnectionConfiguration;


namespace System
{
    public static class ConnectionConfigurationExtensions
    {
        public static StronglyTypedConnectionConfiguration ToStronglyTypedConnectionConfiguration(this ConnectionConfiguration connectionConfiguration)
        {
            var serverName = ServerName.From(connectionConfiguration.ServerName);
            var serverDatabaseName = ServerDatabaseName.From(connectionConfiguration.ServerDatabaseName);

            var stronglyTypedConnectionConfiguration = new StronglyTypedConnectionConfiguration
            {
                ServerName = serverName,
                ServerDatabaseName = serverDatabaseName,
            };

            return stronglyTypedConnectionConfiguration;
        }

        public static NamedConnectionConfiguration ToNamedConnectionConfiguration(this ConnectionConfiguration connectionConfiguration, string databaseNameValue)
        {
            var databaseName = DatabaseName.From(databaseNameValue);
            var stronglyTypedConnectionConfiguration = connectionConfiguration.ToStronglyTypedConnectionConfiguration();

            var namedConnectionConfiguration = new NamedConnectionConfiguration
            {
                DatabaseName = databaseName,
                ConnectionConfiguration = stronglyTypedConnectionConfiguration,
            };

            return namedConnectionConfiguration;
        }
    }
}
