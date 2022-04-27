using System;

using R5T.T0021;

using FileNames = R5T.Dunbar.T001.FileNames;


namespace System
{
    public static class FileNamesExtensions
    {
        public static string DefaultDatabaseConnectionConfigurationJsonFileName(this IFileName _)
        {
            return FileNames.DefaultDatabaseConnectionConfigurationJsonFileName;
        }
    }
}
