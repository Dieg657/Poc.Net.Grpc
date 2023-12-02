using AutoMapper;
using Grpc.Core;
using Poc.Net.Grpc.Application.Interfaces.Services;
using Poc.Net.Grpc.Application.Models.Requests;
using Poc.Net.Grpc.Protos;

namespace Poc.Net.Grpc.Services
{
    public class EmployeeGrpcService(IEmployeeService employeeService, IMapper mapper) : Employee.EmployeeBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IMapper _mapper = mapper;

        public override async Task<Null> Post(EmployeeRequest request, ServerCallContext context)
        {
            await _employeeService.Insert(_mapper.Map<EmployeeRequestModel>(request));
            return new Null();
        }

        public override async Task<EmployeeResponse> Get(Null request, ServerCallContext context)
            => _mapper.Map<EmployeeResponse>(_mapper.Map<IEnumerable<EmployeeResponseData>>(await _employeeService.GetAll()));
    }
}
