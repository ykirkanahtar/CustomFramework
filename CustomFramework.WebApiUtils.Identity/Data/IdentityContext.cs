using CustomFramework.WebApiUtils.Identity.Data.ModelConfigurations;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Identity.Data
{
    public class IdentityContext : IdentityDbContext<User, Role, int>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("users");
            builder.Entity<Role>().ToTable("roles");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");
            builder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
            builder.Entity<IdentityUserRole<int>>().ToTable("user_roles");
            builder.Entity<IdentityUserToken<int>>().ToTable("user_tokens");

            builder.ApplyConfiguration(new ClientApplicationModelConfiguration<ClientApplication>());
        }

        public virtual DbSet<ClientApplication> ClientApplications { get; set; }
    }
}