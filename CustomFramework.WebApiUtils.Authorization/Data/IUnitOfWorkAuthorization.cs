using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data
{
    public interface IUnitOfWorkAuthorization : IUnitOfWork
    {
        IClaimRepository Claims { get; }
        IClientApplicationRepository ClientApplications { get; }
        IClientApplicationUtilRepository ClientApplicationUtils { get; }
        IRoleClaimRepository RoleClaims { get; }
        IRoleEntityClaimRepository RoleEntityClaims { get; }
        IRoleRepository Roles { get; }
        IUserClaimRepository UserClaims { get; }
        IUserEntityClaimRepository UserEntityClaims { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IUserUtilRepository UserUtils { get; }
    }
}