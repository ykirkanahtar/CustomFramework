using CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data
{
    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext(DbContextOptions options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationModelConfiguration<Application>());
            modelBuilder.ApplyConfiguration(new ApplicationUserModelConfiguration<ApplicationUser>());
            modelBuilder.ApplyConfiguration(new ClientApplicationModelConfiguration<ClientApplication>());
            modelBuilder.ApplyConfiguration(new ClientApplicationUtilModelConfiguration<ClientApplicationUtil>());
            modelBuilder.ApplyConfiguration(new UserModelConfiguration<User>());
            modelBuilder.ApplyConfiguration(new RoleModelConfiguration<Role>());
            modelBuilder.ApplyConfiguration(new ClaimModelConfiguration<Claim>());
            modelBuilder.ApplyConfiguration(new RoleClaimModelConfiguration<RoleClaim>());
            modelBuilder.ApplyConfiguration(new UserClaimModelConfiguration<UserClaim>());
            modelBuilder.ApplyConfiguration(new UserRoleModelConfiguration<UserRole>());
            modelBuilder.ApplyConfiguration(new UserUtilModelConfiguration<UserUtil>());
            modelBuilder.ApplyConfiguration(new RoleEntityClaimModelConfiguration<RoleEntityClaim>());
            modelBuilder.ApplyConfiguration(new UserEntityClaimModelConfiguration<UserEntityClaim>());
        }
    }
}