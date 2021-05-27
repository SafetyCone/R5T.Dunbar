using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class ServerAuthenticationName : TypedString
    {
        #region Static

        public static ServerAuthenticationName From(string value)
        {
            var output = new ServerAuthenticationName(value);
            return output;
        }

        #endregion


        public ServerAuthenticationName(string value)
            : base(value)
        {
        }
    }
}
