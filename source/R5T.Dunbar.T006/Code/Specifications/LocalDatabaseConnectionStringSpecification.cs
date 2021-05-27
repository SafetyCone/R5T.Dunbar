using System;


namespace R5T.Dunbar.T006
{
    /// <summary>
    /// Contains all information required to create a connection string for a local database.
    /// </summary>
    public class LocalDatabaseConnectionStringSpecification
    {
        public ServerDatabaseName ServerDatabaseName { get; set; }
        public LocalBaseConnectionString BaseConnectionString { get; set; }
    }
}
