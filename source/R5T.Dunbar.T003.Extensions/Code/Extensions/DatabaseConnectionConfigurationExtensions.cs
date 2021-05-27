using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Dunbar.T003;
using R5T.Dunbar.T005;
using R5T.Dunbar.T006;

using StronlyTypedDatabaseConnectionConfiguration = R5T.Dunbar.T007.DatabaseConnectionConfiguration;


namespace System
{
    public static class DatabaseConnectionConfigurationExtensions
    {
        public static void FillStronglyTypedDatabaseConnectionConfiguration(this DatabaseConnectionConfiguration databaseConnectionConfiguration, StronlyTypedDatabaseConnectionConfiguration stronglyTypedDatabaseConnectionConfiguration)
        {
            stronglyTypedDatabaseConnectionConfiguration.ConnectionConfigurationsByDatabaseName = databaseConnectionConfiguration.ConnectionConfigurationsByDatabaseName
                    ?.Select(pair =>
                    {
                        var namedConnectionConfiguration = pair.Value.ToNamedConnectionConfiguration(pair.Key);
                        return namedConnectionConfiguration;
                    })
                    .ToDictionary(
                    x => x.DatabaseName)
                    ?? new Dictionary<DatabaseName, NamedConnectionConfiguration>();

            stronglyTypedDatabaseConnectionConfiguration.ConnectionStringsByDatabaseName = databaseConnectionConfiguration.ConnectionStringsByDatabaseName
                    ?.Select(pair =>
                    {
                        var namedConnectionString = NamedConnectionString.From(pair.Key, pair.Value);
                        return namedConnectionString;
                    })
                    .ToDictionary(
                    x => x.DatabaseName)
                    ?? new Dictionary<DatabaseName, NamedConnectionString>();

            stronglyTypedDatabaseConnectionConfiguration.DatabaseName = databaseConnectionConfiguration.DatabaseName is object
                    ? DatabaseName.From(databaseConnectionConfiguration.DatabaseName)
                    : null;

            stronglyTypedDatabaseConnectionConfiguration.LocalBaseConnectionString = databaseConnectionConfiguration.LocalBaseConnectionString is object
                    ? LocalBaseConnectionString.From(databaseConnectionConfiguration.LocalBaseConnectionString)
                    : null;

            stronglyTypedDatabaseConnectionConfiguration.ServerAuthenticationsByServerAuthenticationName = databaseConnectionConfiguration.ServerAuthenticationsByServerAuthenticationName
                    .Select(pair =>
                    {
                        var namedServerAuthentication = pair.Value.ToNamedServerAuthentication(pair.Key);
                        return namedServerAuthentication;
                    })
                    .ToDictionary(
                    x => x.ServerAuthenticationName);

            stronglyTypedDatabaseConnectionConfiguration.ServerConfigurationsByServerName = databaseConnectionConfiguration.ServerConfigurationsByServerName
                    .Select(pair =>
                    {
                        var namedServerConfiguration = pair.Value.ToNamedServerConfiguration(pair.Key);
                        return namedServerConfiguration;
                    })
                    .ToDictionary(
                    x => x.ServerName);

            stronglyTypedDatabaseConnectionConfiguration.ServerLocationsByServerLocationName = databaseConnectionConfiguration.ServerLocationsByServerLocationName
                    .Select(pair =>
                    {
                        var namedServerLocation = NamedServerLocation.From(pair.Key, pair.Value);
                        return namedServerLocation;
                    })
                    .ToDictionary(
                    x => x.ServerLocationName);
        }

        public static StronlyTypedDatabaseConnectionConfiguration ToStronglyTypedDatabaseConnectionConfiguration(this DatabaseConnectionConfiguration databaseConnectionConfiguration)
        {
            var stronglyTypedDatabaseConnectionConfiguration = new StronlyTypedDatabaseConnectionConfiguration();

            databaseConnectionConfiguration.FillStronglyTypedDatabaseConnectionConfiguration(stronglyTypedDatabaseConnectionConfiguration);

            return stronglyTypedDatabaseConnectionConfiguration;
        }
    }
}
