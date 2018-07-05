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

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ClientApplication> ClientApplications { get; set; }
        public virtual DbSet<ClientApplicationUtil> ClientApplicationUtils { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserUtil> UserUtils { get; set; }
        public virtual DbSet<RoleEntityClaim> RoleEntityClaims { get; set; }
        public virtual DbSet<UserEntityClaim> UserEntityClaims { get; set; }

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