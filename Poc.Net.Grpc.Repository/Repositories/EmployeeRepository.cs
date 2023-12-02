using Dapper;
using Poc.Net.Grpc.Domain.Entities;
using Poc.Net.Grpc.Repository.Interfaces.Employee;
using Poc.Net.Grpc.Repository.Queries;
using System.Data;

namespace Poc.Net.Grpc.Repository.Repositories
{
    public class EmployeeRepository(IDbConnection connection) : IEmployeeRepository
    {
        private readonly IDbConnection _connection = connection;

        public async Task<IEnumerable<Employee>> GetAll()
            => await _connection.QueryAsync<Employee>(EmployeeQueries.QueryAll) ?? new List<Employee>();

        public async Task Insert(Employee model)
            => await _connection.ExecuteAsync(EmployeeQueries.InsertEmployee, model);
    }
}
