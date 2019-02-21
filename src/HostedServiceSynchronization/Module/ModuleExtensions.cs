using System.Threading;
using System.Threading.Tasks;
using HostedServiceSynchronization.Module;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddSingleton<ModuleSession>();
            services.AddHostedService<ModuleInitializer>();

            return services;
        }
    }
}