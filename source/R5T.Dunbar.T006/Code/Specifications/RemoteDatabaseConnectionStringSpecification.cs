using System;


namespace R5T.Dunbar.T006
{
    public class RemoteDatabaseConnectionStringSpecification
    {
        public ServerDatabaseName ServerDatabaseName { get; set; }
        public ServerLocation ServerLocation { get; set; }
        public ServerAuthentication ServerAuthentication { get; set; }
    }
}
