using AutoMapper;
using Poc.Net.Grpc.Application.Interfaces.Services;
using Poc.Net.Grpc.Application.Models.Requests;
using Poc.Net.Grpc.Application.Models.Responses;
using Poc.Net.Grpc.Domain.Entities;
using Poc.Net.Grpc.Repository.Interfaces.Employee;

namespace Poc.Net.Grpc.Application.Services
{
    public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
    {
        private readonly IEmployeeRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<EmployeeResponseModel>> GetAll()
            => _mapper.Map<IEnumerable<EmployeeResponseModel>>(await _repository.GetAll());

        public async Task Insert(EmployeeRequestModel model)
            => await _repository.Insert(_mapper.Map<Employee>(model));
    }
}
