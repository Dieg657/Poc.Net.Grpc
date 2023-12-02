using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Grpc.Setup.Modules;

namespace Poc.Net.Grpc.Setup
{
    public static class Setup
    {
        public static IServiceCollection RegisterContainer(this IServiceCollection services, IConfiguration configuration)
            => services.RegisterInfraModules(configuration)
                       .RegisterApplicationModules();
    }
}
