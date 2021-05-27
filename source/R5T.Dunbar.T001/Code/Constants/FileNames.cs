using System;


namespace R5T.Dunbar.T001
{
    /// <summary>
    /// Private class can have constants that won't leak into other compiled assemblies.
    /// </summary>
    class FileNames
    {
        public const string DefaultDatabaseConnectionConfigurationJsonFileName = "DatabaseConnectionConfiguration.json";
    }
}
