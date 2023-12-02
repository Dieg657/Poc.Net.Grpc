using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Grpc.Application.Interfaces.Services;
using Poc.Net.Grpc.Application.Services;
using System.Reflection;

namespace Poc.Net.Grpc.Setup.Modules
{
    internal static class ApplicationModules
    {
        public static IServiceCollection RegisterApplicationModules(this IServiceCollection services)
            => services.RegisterAutoMapper()
                       .RegisterServices();

        private static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.Load("Poc.Net.Grpc.Application"));

        private static IServiceCollection RegisterServices(this IServiceCollection services)
            => services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
