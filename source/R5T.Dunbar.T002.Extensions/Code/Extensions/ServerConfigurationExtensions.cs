using System;

using R5T.Magyar;

using R5T.T0023;

using R5T.Dunbar.T006;

using ServerConfiguration = R5T.Dunbar.T002.ServerConfiguration;
using StronglyTypedServerConfiguration = R5T.Dunbar.T006.ServerConfiguration;


namespace System
{
    public static class ServerConfigurationExtensions
    {
        public static StronglyTypedServerConfiguration ToStronglyTypedServerConfiguration(this ServerConfiguration serverConfiguration)
        {
            var localOrRemote = EnumerationHelper.GetValue<LocalOrRemote>(serverConfiguration.LocalOrRemote);
            var serverAuthenticationName = ServerAuthenticationName.From(serverConfiguration.ServerAuthenticationName);
            var serverLocationName = ServerLocationName.From(serverConfiguration.ServerLocationName);

            var stronglyTypedServerConfiguration = new StronglyTypedServerConfiguration
            {
                LocalOrRemote = localOrRemote,
                ServerAuthenticationName = serverAuthenticationName,
                ServerLocationName = serverLocationName,
            };

            return stronglyTypedServerConfiguration;
        }

        public static NamedServerConfiguration ToNamedServerConfiguration(this ServerConfiguration serverConfiguration, string serverNameValue)
        {
            var serverName = ServerName.From(serverNameValue);
            var stronglyTypedServerConfiguration = serverConfiguration.ToStronglyTypedServerConfiguration();

            var namedServerConfiguration = new NamedServerConfiguration
            {
                ServerName = serverName,
                ServerConfiguration = stronglyTypedServerConfiguration,
            };

            return namedServerConfiguration;
        }
    }
}
