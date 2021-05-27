using System;

using R5T.T0023;


namespace R5T.Dunbar.T006
{
    public class ServerConfiguration
    {
        public LocalOrRemote LocalOrRemote { get; set; }
        public ServerAuthenticationName ServerAuthenticationName { get; set; }
        public ServerLocationName ServerLocationName { get; set; }
    }
}
