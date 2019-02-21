using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedServiceSynchronization.Module
{
    public class ModuleInitializer : BackgroundService
    {
        private readonly ModuleSession moduleSession;
        private readonly ILogger<ModuleInitializer> logger;

        public ModuleInitializer(ModuleSession moduleSession, ILogger<ModuleInitializer> logger)
        {
            this.moduleSession = moduleSession;
            this.logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            logger.LogInformation($"{GetType().Name}================ STARTING INIT =============");
            moduleSession.Initialize();
            logger.LogInformation($"{GetType().Name}================ INIT IS DONE =============");
        }
    }
}