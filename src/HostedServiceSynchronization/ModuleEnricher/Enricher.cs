using System.Threading;
using System.Threading.Tasks;
using HostedServiceSynchronization.Module;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedServiceSynchronization.ModuleEnricher
{
    public class Enricher : IHostedService
    {
        private readonly ModuleSession moduleSession;
        private readonly ILogger<Enricher> logger;

        public Enricher(ModuleSession moduleSession, ILogger<Enricher> logger)
        {
            this.moduleSession = moduleSession;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"{GetType().Name}================ WAITING FOR SESSION =============");
            await moduleSession.GetSessionAsync();
            logger.LogInformation($"{GetType().Name}================ SESSION IS READY =============");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}