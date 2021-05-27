using System;

using R5T.T0024;


namespace R5T.Dunbar.Construction
{
    public static class IDatabaseNamesExtensions
    {
        public static string LocalDevelopment(this IDatabaseNames databaseNames)
        {
            return "LocalDevelopment";
        }

        public static string LocalDevelopment2(this IDatabaseNames databaseNames)
        {
            return "LocalDevelopment2";
        }

        public static string RemoteDevelopment(this IDatabaseNames databaseNames)
        {
            return "RemoteDevelopment";
        }
    }
}
