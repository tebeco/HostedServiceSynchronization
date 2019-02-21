using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedServiceSynchronization.Module
{
    public class ModuleSession
    {
        private TaskCompletionSource<ModuleSession> sessionInitializationTcs = new TaskCompletionSource<ModuleSession>();
        private readonly ILogger<ModuleSession> logger;

        public ModuleSession(ILogger<ModuleSession> logger)
        {
            this.logger = logger;
        }

        public void Initialize()
        {
            logger.LogInformation($"{GetType().Name}================ INITIALIZING =============");

            Thread.Sleep(5000);

            logger.LogInformation($"{GetType().Name}================ SET RESULT =============");
            sessionInitializationTcs.SetResult(this);
        }

        public Task<ModuleSession> GetSessionAsync()
        {
            return sessionInitializationTcs.Task;
        }
    }
}