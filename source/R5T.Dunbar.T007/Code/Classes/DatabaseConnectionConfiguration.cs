using System;
using System.Collections.Generic;

using R5T.Dunbar.T005;
using R5T.Dunbar.T006;


namespace R5T.Dunbar.T007
{
    public class DatabaseConnectionConfiguration
    {
        #region Static

        /// <summary>
        /// All collection properties are initialized.
        /// </summary>
        public static DatabaseConnectionConfiguration New()
        {
            var output = new DatabaseConnectionConfiguration
            {
                ConnectionConfigurationsByDatabaseName = new Dictionary<DatabaseName, NamedConnectionConfiguration>(),
                ConnectionStringsByDatabaseName = new Dictionary<DatabaseName, NamedConnectionString>(),
                ServerAuthenticationsByServerAuthenticationName = new Dictionary<ServerAuthenticationName, NamedServerAuthentication>(),
                ServerConfigurationsByServerName = new Dictionary<ServerName, NamedServerConfiguration>(),
                ServerLocationsByServerLocationName = new Dictionary<ServerLocationName, NamedServerLocation>(),
            };

            return output;
        }

        #endregion


        public DatabaseName DatabaseName { get; set; }
        public Dictionary<DatabaseName, NamedConnectionString> ConnectionStringsByDatabaseName { get; set; }
        public Dictionary<DatabaseName, NamedConnectionConfiguration> ConnectionConfigurationsByDatabaseName { get; set; }
        public Dictionary<ServerName, NamedServerConfiguration> ServerConfigurationsByServerName { get; set; }
        public Dictionary<ServerLocationName, NamedServerLocation> ServerLocationsByServerLocationName { get; set; }
        public Dictionary<ServerAuthenticationName, NamedServerAuthentication> ServerAuthenticationsByServerAuthenticationName { get; set; }
        public LocalBaseConnectionString LocalBaseConnectionString { get; set; }
    }
}
