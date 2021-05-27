﻿using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using R5T.Dunbar.T007;


namespace R5T.Dunbar.D003.I001
{
    public class DatabaseConnectionConfigurationProvider : IDatabaseConnectionConfigurationProvider
    {
        private IOptions<DatabaseConnectionConfiguration> Options { get; }


        public DatabaseConnectionConfigurationProvider(
            IOptions<DatabaseConnectionConfiguration> options)
        {
            this.Options = options;
        }

        public Task<DatabaseConnectionConfiguration> GetDatabaseConnectionConfiguration()
        {
            return Task.FromResult(this.Options.Value);
        }
    }
}
