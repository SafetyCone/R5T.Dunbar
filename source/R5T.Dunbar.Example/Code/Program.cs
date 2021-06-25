using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using R5T.Plymouth;
using R5T.Plymouth.ProgramAsAService;

using R5T.Dunbar.Example.Operations;


namespace R5T.Dunbar.Example
{
    class Program : ProgramAsAServiceBase
    {
        
        #region Main

        static Task Main()
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .UseStartup<Startup, StartupForConfiguration>()
                .UseProgramAsAService<Program>()
                .BuildProgramAsAServiceHost()
                .Run();
        }

        #endregion


        private IServiceProvider ServiceProvider { get; }


        public Program(IApplicationLifetime applicationLifetime,
            IServiceProvider serviceProvider)
            : base(applicationLifetime)
        {
            this.ServiceProvider = serviceProvider;
        }

        protected override async Task ServiceMain(CancellationToken stoppingToken)
        {
            //await this.ServiceProvider.Run<GetExampleRepository>();
            await this.ServiceProvider.Run<GetExampleRepositoriesFromNamedSources>();
        }
    }
}
