using AutoMapper;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.AutoMapper
{
    public class IdentityMappingProfile : Profile
    {
        public void Map()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<ClientApplication, ClientApplicationResponse>();
            CreateMap<ClientApplicationRequest, ClientApplication>();
        }
    }
}