using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class ServerName : TypedString
    {
        #region Static

        public static ServerName From(string value)
        {
            var output = new ServerName(value);
            return output;
        }

        #endregion


        public ServerName(string value)
            : base(value)
        {
        }
    }
}
