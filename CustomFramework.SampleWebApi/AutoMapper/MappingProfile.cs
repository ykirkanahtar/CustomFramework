using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Response;
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