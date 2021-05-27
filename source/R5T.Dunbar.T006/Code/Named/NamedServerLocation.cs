using System;


namespace R5T.Dunbar.T006
{
    public class NamedServerLocation
    {
        #region Static

        public static NamedServerLocation From(string serverLocationNameValue, string serverLocationValue)
        {
            var serverLocationName = ServerLocationName.From(serverLocationNameValue);
            var serverLocation = ServerLocation.From(serverLocationValue);

            var output = new NamedServerLocation
            {
                ServerLocationName = serverLocationName,
                ServerLocation = serverLocation,
            };

            return output;
        }

        #endregion


        public ServerLocationName ServerLocationName { get; set; }
        public ServerLocation ServerLocation { get; set; }
    }
}
