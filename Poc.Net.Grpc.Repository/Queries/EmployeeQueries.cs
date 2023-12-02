using Poc.Net.Grpc.Domain.Entities;

namespace Poc.Net.Grpc.Repository.Queries
{
    internal static class EmployeeQueries
    {
        public const string QueryAll = "SELECT * FROM Employees (NOLOCK)";
        public const string InsertEmployee = $@"INSERT INTO Employees (Role, Company, Location, Remote, Link, Salary, CreatedAt)
                                                VALUES (@{nameof(Employee.Role)}, 
                                                        @{nameof(Employee.Company)}, 
                                                        @{nameof(Employee.Location)}, 
                                                        @{nameof(Employee.Remote)}, 
                                                        @{nameof(Employee.Link)}, 
                                                        @{nameof(Employee.Salary)}, 
                                                        SYSDATETIMEOFFSET())";
    }
}
