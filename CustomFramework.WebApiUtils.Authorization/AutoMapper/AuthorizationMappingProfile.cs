using AutoMapper;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Contracts.Responses;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.AutoMapper
{
    public class AuthorizationMappingProfile : Profile
    {
        public void Map()
        {
            /*Authorization*/
            CreateMap<Claim, ClaimResponse>();
            CreateMap<ClaimRequest, Claim>();

            CreateMap<ClientApplication, ClientApplicationResponse>();
            CreateMap<ClientApplicationRequest, ClientApplication>();
            CreateMap<ClientApplicationUpdateRequest, ClientApplication>();
            CreateMap<ClientApplicationUtilRequest, ClientApplication>();

            CreateMap<Role, RoleResponse>();
            CreateMap<RoleRequest, Role>();

            CreateMap<RoleClaim, RoleClaimResponse>();
            CreateMap<RoleClaimRequest, RoleClaim>();

            CreateMap<RoleEntityClaimRequest, RoleEntityClaim>();
            CreateMap<RoleEntityClaim, RoleEntityClaimResponse>();
            CreateMap<EntityClaimRequest, RoleEntityClaim>();

            CreateMap<UserClaim, UserClaimResponse>();
            CreateMap<UserClaimRequest, UserClaim>();

            CreateMap<UserEntityClaim, UserEntityClaimResponse>();
            CreateMap<UserEntityClaimRequest, UserEntityClaim>();
            CreateMap<EntityClaimRequest, UserEntityClaim>();

            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();

            CreateMap<UserRole, UserRoleResponse>();
            CreateMap<UserRoleRequest, UserRole>();

            CreateMap<UserUtilRequest, UserUtil>();
            /*Authorization*/
        }
    }
}