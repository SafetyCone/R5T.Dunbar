using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0024;

using IParameterlessConnectionStringProvider = R5T.Dunbar.D004.IConnectionStringProvider;
using IParameterizedConnectionStringProvider = R5T.Dunbar.D005.IConnectionStringProvider;


namespace R5T.Dunbar.Construction.Operations
{
    public class GetDatabaseConnectionString : IActionOperation
    {
        private IParameterizedConnectionStringProvider ParameterizedConnectionStringProvider { get; }
        private IParameterlessConnectionStringProvider ParameterlessConnectionStringProvider { get; }


        public GetDatabaseConnectionString(
            IParameterizedConnectionStringProvider parameterizedConnectionStringProvider,
            IParameterlessConnectionStringProvider parameterlessConnectionStringProvider)
        {
            this.ParameterizedConnectionStringProvider = parameterizedConnectionStringProvider;
            this.ParameterlessConnectionStringProvider = parameterlessConnectionStringProvider;
        }

        public async Task Run()
        {
            var defaultConnectionString = await this.ParameterlessConnectionStringProvider.GetConnectionString();

            var localDevelopentConnectionString = await this.ParameterizedConnectionStringProvider.GetConnectionString(DatabaseNames.Instance.LocalDevelopment());
            var localDevelopent2ConnectionString = await this.ParameterizedConnectionStringProvider.GetConnectionString(DatabaseNames.Instance.LocalDevelopment2());
            var remoteDevelopentConnectionString = await this.ParameterizedConnectionStringProvider.GetConnectionString(DatabaseNames.Instance.RemoteDevelopment());
        }
    }
}
