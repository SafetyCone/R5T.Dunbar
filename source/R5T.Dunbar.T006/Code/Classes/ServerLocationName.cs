using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class ServerLocationName : TypedString
    {
        #region Static

        public static ServerLocationName From(string value)
        {
            var output = new ServerLocationName(value);
            return output;
        }

        #endregion


        public ServerLocationName(string value)
            : base(value)
        {
        }
    }
}
