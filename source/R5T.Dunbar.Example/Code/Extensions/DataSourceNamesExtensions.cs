using System;

using R5T.T0026;


namespace R5T.Dunbar.Example
{
    public static class DataSourceNamesExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static string GetLocalDevelopment(this IDataSourceNames dataSourceNames)
        {
            return "LocalDevelopment";
        }

        public static string GetRemoteDevelopment(this IDataSourceNames dataSourceNames)
        {
            return "RemoteDevelopment";
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
