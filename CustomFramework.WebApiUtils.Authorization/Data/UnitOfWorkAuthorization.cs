using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data
{
    public class UnitOfWorkAuthorization : UnitOfWork<AuthorizationContext>, IUnitOfWorkAuthorization
    {
        public UnitOfWorkAuthorization(AuthorizationContext context) : base(context)
        {
            Claims = new ClaimRepository(context);
            ClientApplications = new ClientApplicationRepository(context);
            ClientApplicationUtils = new ClientApplicationUtilRepository(context);
            RoleClaims = new RoleClaimRepository(context);
            RoleEntityClaims = new RoleEntityClaimRepository(context);
            Roles = new RoleRepository(context);
            UserClaims = new UserClaimRepository(context);
            UserEntityClaims = new UserEntityClaimRepository(context);
            Users = new UserRepository(context);
            UserRoles = new UserRoleRepository(context);
            UserUtils = new UserUtilRepository(context);
        }

        public IClaimRepository Claims { get; }
        public IClientApplicationRepository ClientApplications { get; }
        public IClientApplicationUtilRepository ClientApplicationUtils { get; }
        public IRoleClaimRepository RoleClaims { get; }
        public IRoleEntityClaimRepository RoleEntityClaims { get; }
        public IRoleRepository Roles { get; }
        public IUserClaimRepository UserClaims { get; }
        public IUserEntityClaimRepository UserEntityClaims { get; }
        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }
        public IUserUtilRepository UserUtils { get; }
    }
}