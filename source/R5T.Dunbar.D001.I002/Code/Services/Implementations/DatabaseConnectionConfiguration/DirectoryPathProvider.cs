﻿using System;
using System.Threading.Tasks;

using R5T.D0070;
using R5T.T0064;

using R5T.Dunbar.D001.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D001.I002.DatabaseConnectionConfiguration
{
    [ServiceImplementationMarker]
    public class DirectoryPathProvider : IDirectoryPathProvider, IServiceImplementation
    {
        private IAppSettingsDirectoryPathProvider AppSettingsDirectoryPathProvider { get; }


        public DirectoryPathProvider(
            IAppSettingsDirectoryPathProvider appSettingsDirectoryPathProvider)
        {
            this.AppSettingsDirectoryPathProvider = appSettingsDirectoryPathProvider;
        }

        public Task<string> GetDirectoryPath()
        {
            // Just return the AppSettings directory path.
            return this.AppSettingsDirectoryPathProvider.GetAppSettingsDirectoryPath();
        }
    }
}
