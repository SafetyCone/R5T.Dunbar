using System;

using R5T.T0022;

using ConfigurationSectionNames = R5T.Dunbar.T004.ConfigurationSectionNames;


namespace System
{
    public static class ConfigurationSectionNamesExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static string DatabaseConnectionConfiguration(this IConfigurationSectionNames configurationSectionNames)
        {
            return ConfigurationSectionNames.DatabaseConnectionConfiguration;
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
