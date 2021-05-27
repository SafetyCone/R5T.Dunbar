using System;

using R5T.Stagira;


namespace R5T.Dunbar.T005
{
    public class DatabaseName : TypedString
    {
        #region Static

        public static DatabaseName From(string value)
        {
            var output = new DatabaseName(value);
            return output;
        }

        #endregion


        public DatabaseName(string value)
            : base(value)
        {
        }
    }
}
