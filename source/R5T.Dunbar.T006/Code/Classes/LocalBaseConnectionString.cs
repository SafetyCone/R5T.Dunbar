using System;

using R5T.Stagira;


namespace R5T.Dunbar.T006
{
    public class LocalBaseConnectionString : TypedString
    {
        #region Static

        public static LocalBaseConnectionString From(string value)
        {
            var output = new LocalBaseConnectionString(value);
            return output;
        }

        #endregion


        public LocalBaseConnectionString(string value)
            : base(value)
        {
        }
    }
}
