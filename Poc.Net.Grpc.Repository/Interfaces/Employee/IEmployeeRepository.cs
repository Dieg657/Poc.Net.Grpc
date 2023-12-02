namespace Poc.Net.Grpc.Repository.Interfaces.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Domain.Entities.Employee>> GetAll();
        Task Insert(Domain.Entities.Employee model);
    }
}
