using System;

using R5T.Dunbar.T005;


namespace R5T.Dunbar.T006
{
    public class NamedConnectionString
    {
        #region Static

        public static NamedConnectionString From(string databaseNameValue, string connectionStringValue)
        {
            var databaseName = DatabaseName.From(databaseNameValue);
            var connectionString = ConnectionString.From(connectionStringValue);

            var namedConnectionString = new NamedConnectionString
            {
                DatabaseName = databaseName,
                ConnectionString = connectionString,
            };

            return namedConnectionString;
        }

        #endregion


        public DatabaseName DatabaseName { get; set; }
        public ConnectionString ConnectionString { get; set; }
    }
}
