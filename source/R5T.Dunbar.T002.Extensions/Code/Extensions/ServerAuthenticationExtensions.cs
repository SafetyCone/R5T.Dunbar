using System;

using R5T.Dunbar.T006;

using ServerAuthentication = R5T.Dunbar.T002.ServerAuthentication;
using StronglyTypedServerAuthentication = R5T.Dunbar.T006.ServerAuthentication;


namespace System
{
    public static class ServerAuthenticationExtensions
    {
        public static StronglyTypedServerAuthentication ToStronglyTypedServerAuthentication(this ServerAuthentication serverAuthentication)
        {
            var stronglyTypedServerAuthentication = new StronglyTypedServerAuthentication
            {
                Username = serverAuthentication.Username,
                Password = serverAuthentication.Password,
            };

            return stronglyTypedServerAuthentication;
        }

        public static NamedServerAuthentication ToNamedServerAuthentication(this ServerAuthentication serverAuthentication, string serverAuthenticationNameValue)
        {
            var serverAuthenticationName = ServerAuthenticationName.From(serverAuthenticationNameValue);
            var stronglyTypedServerAuthentication = serverAuthentication.ToStronglyTypedServerAuthentication();

            var namedServerAuthentication = new NamedServerAuthentication
            {
                ServerAuthenticationName = serverAuthenticationName,
                ServerAuthentication = stronglyTypedServerAuthentication,
            };

            return namedServerAuthentication;
        }
    }
}
