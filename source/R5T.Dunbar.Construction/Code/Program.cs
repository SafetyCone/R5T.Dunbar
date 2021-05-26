using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using R5T.Plymouth;
using R5T.Plymouth.ProgramAsAService;


namespace R5T.Dunbar.Construction
{
    class Program : ProgramAsAServiceBase
    {
        #region Main

        static Task Main(string[] args)
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .UseStartup<Startup>()
                .UseProgramAsAService<Program>()
                .BuildProgramAsAServiceHost()
                .Run();
        }

        #endregion

        public Program(IApplicationLifetime applicationLifetime)
            : base(applicationLifetime)
        {
        }

        protected override Task ServiceMain(CancellationToken stoppingToken)
        {
            Console.WriteLine("Hello world!");

            return Task.CompletedTask;
        }
    }
}
