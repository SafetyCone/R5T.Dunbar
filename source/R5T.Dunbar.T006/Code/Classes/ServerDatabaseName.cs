using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class ServerDatabaseName : TypedString
    {
        #region Static

        public static ServerDatabaseName From(string value)
        {
            var output = new ServerDatabaseName(value);
            return output;
        }

        #endregion


        public ServerDatabaseName(string value)
            : base(value)
        {
        }
    }
}
