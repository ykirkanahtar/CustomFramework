using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.SampleWebApi.Responses;
using CustomFramework.WebApiUtils.Authorization.AutoMapper;

namespace CustomFramework.SampleWebApi.AutoMapper
{
    public class MappingProfile : AuthorizationMappingProfile
    {
        public MappingProfile()
        {
            Map();

            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();

            CreateMap<CurrentAccount, CurrentAccountResponse>();
            CreateMap<CurrentAccountRequest, CurrentAccount>();
        }
    }
}