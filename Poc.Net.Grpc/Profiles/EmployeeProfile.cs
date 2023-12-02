using AutoMapper;
using Poc.Net.Grpc.Application.Models.Requests;
using Poc.Net.Grpc.Application.Models.Responses;
using Poc.Net.Grpc.Protos;

namespace Poc.Net.Grpc.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<EmployeeRequest, EmployeeRequestModel>();
            CreateMap<EmployeeResponseModel, EmployeeResponseData>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Salary, opt => opt.MapFrom(src => (double)src.Salary))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString()))
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt.HasValue ? src.UpdatedAt.ToString() : string.Empty))
                .ForMember(x => x.DeletedAt, opt => opt.MapFrom(src => src.DeletedAt.HasValue ? src.DeletedAt.ToString() : string.Empty));
            CreateMap<IEnumerable<EmployeeResponseData>, EmployeeResponse>()
                .ForMember(x => x.Data, opt => opt.MapFrom(src => src));
        }
    }
}
