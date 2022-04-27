using System;

using Microsoft.Extensions.Options;

using R5T.T0064;

using R5T.Dunbar.T007;

using RawDatabaseConnectionConfiguration = R5T.Dunbar.T003.DatabaseConnectionConfiguration;


namespace R5T.Dunbar.D003.I001
{
    [ServiceImplementationMarker]
    public class DatabaseConnectionConfigurationConfigureOptions : IConfigureOptions<DatabaseConnectionConfiguration>, IServiceImplementation
    {
        private IOptions<RawDatabaseConnectionConfiguration> RawOptions { get; }


        public DatabaseConnectionConfigurationConfigureOptions(
            IOptions<RawDatabaseConnectionConfiguration> rawOptions)
        {
            this.RawOptions = rawOptions;
        }

        public void Configure(DatabaseConnectionConfiguration options)
        {
            var rawDatabaseConnectionConfiguration = this.RawOptions.Value;

            rawDatabaseConnectionConfiguration.FillStronglyTypedDatabaseConnectionConfiguration(options);
        }
    }
}
