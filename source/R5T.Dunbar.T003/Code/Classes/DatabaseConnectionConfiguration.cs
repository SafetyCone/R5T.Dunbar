using System;
using System.Collections.Generic;

using R5T.Dunbar.T002;


namespace R5T.Dunbar.T003
{
    public class DatabaseConnectionConfiguration
    {
        public string DatabaseName { get; set; }
        public Dictionary<string, string> ConnectionStringsByDatabaseName { get; set; }
        public Dictionary<string, ConnectionConfiguration> ConnectionConfigurationsByDatabaseName { get; set; }
        public Dictionary<string, ServerConfiguration> ServerConfigurationsByServerName { get; set; }
        public Dictionary<string, string> ServerLocationsByServerLocationName { get; set; }
        public Dictionary<string, ServerAuthentication> ServerAuthenticationsByServerAuthenticationName { get; set; }
        public string LocalBaseConnectionString { get; set; }
    }
}
