using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0026;

using R5T.D0072;

using R5T.Dunbar.Example.Repository;


namespace R5T.Dunbar.Example.Operations
{
    public class GetExampleRepositoriesFromNamedSources : IOperation
    {
        private IRepositoryProvider<IExampleRepository> RepositoryProvider { get; }


        public GetExampleRepositoriesFromNamedSources(
            IRepositoryProvider<IExampleRepository> repositoryProvider)
        {
            this.RepositoryProvider = repositoryProvider;
        }

        public async Task Run()
        {
            var localDev = await this.RepositoryProvider.GetRepository(DataSourceNames.Instance.GetLocalDevelopment());
            var remoteDev = await this.RepositoryProvider.GetRepository(DataSourceNames.Instance.GetRemoteDevelopment());

            //await localDev.Add("test");
            await remoteDev.Add("test");
        }
    }
}
