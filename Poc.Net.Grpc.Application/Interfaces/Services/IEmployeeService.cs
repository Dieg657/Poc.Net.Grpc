using Poc.Net.Grpc.Application.Models.Requests;
using Poc.Net.Grpc.Application.Models.Responses;

namespace Poc.Net.Grpc.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task Insert(EmployeeRequestModel model);
        Task<IEnumerable<EmployeeResponseModel>> GetAll();
    }
}
