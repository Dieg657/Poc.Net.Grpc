using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Grpc.Repository.Interfaces.Employee;
using Poc.Net.Grpc.Repository.Repositories;
using System.Data;

namespace Poc.Net.Grpc.Setup.Modules
{
    internal static class InfrastructureModules
    {
        public static IServiceCollection RegisterInfraModules(this IServiceCollection services, IConfiguration configuration)
            => services.ConfigureConnection(configuration)
                       .ConfigureRepositories();

        private static IServiceCollection ConfigureConnection(this IServiceCollection services, IConfiguration configuration)
            => services.AddTransient<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("MSSQL_CONNECTION")));

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
            => services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}
