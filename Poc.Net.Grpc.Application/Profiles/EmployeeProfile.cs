using AutoMapper;
using Poc.Net.Grpc.Application.Models.Requests;
using Poc.Net.Grpc.Application.Models.Responses;
using Poc.Net.Grpc.Domain.Entities;

namespace Poc.Net.Grpc.Application.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<EmployeeRequestModel, Employee>();
            CreateMap<Employee, EmployeeResponseModel>();
        }
    }
}
