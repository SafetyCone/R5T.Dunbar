using System;

using R5T.Stagira;


namespace R5T.Dunbar.T005
{
    public class ConnectionString : TypedString
    {
        #region Static

        public static ConnectionString From(string value)
        {
            var output = new ConnectionString(value);
            return output;
        }

        #endregion


        public ConnectionString(string value)
            : base(value)
        {
        }
    }
}
