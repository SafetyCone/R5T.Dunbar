using System;

using R5T.T0021;

using FileNames = R5T.Dunbar.T001.FileNames;


namespace System
{
    public static class FileNamesExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static string DefaultDatabaseConnectionConfigurationJsonFileName(this IFileNames fileNames)
        {
            return FileNames.DefaultDatabaseConnectionConfigurationJsonFileName;
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
