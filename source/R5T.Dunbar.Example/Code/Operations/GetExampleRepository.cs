using System;
using System.Threading.Tasks;

using R5T.Dunbar.Example.Repository;

using R5T.T0020;


namespace R5T.Dunbar.Example.Operations
{
    public class GetExampleRepository : IOperation
    {
        private IExampleRepository ExampleRepository { get; }


        public GetExampleRepository(
            IExampleRepository exampleRepository)
        {
            this.ExampleRepository = exampleRepository;
        }

        public async Task Run()
        {
            await this.ExampleRepository.Add("Test");
        }
    }
}
