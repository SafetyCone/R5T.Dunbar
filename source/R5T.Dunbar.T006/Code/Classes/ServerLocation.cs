using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class ServerLocation : TypedString
    {
        #region Static

        public static ServerLocation From(string value)
        {
            var output = new ServerLocation(value);
            return output;
        }

        #endregion


        public ServerLocation(string value)
            : base(value)
        {
        }
    }
}
