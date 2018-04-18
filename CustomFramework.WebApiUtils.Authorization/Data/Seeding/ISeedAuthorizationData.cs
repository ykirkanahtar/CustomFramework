using System.Collections.Generic;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Seeding
{
    public interface ISeedAuthorizationData
    {
        IList<ClientApplication> ClientApplications { get; set; }
        IList<Role> Roles { get; set; }
        IList<User> Users { get; set; }
        IList<UserRole> UserRoles { get; set; }
        IList<RoleEntityClaim> RoleEntityClaims { get; set; }
        void SeedUserData(ModelBuilder modelBuilder);
        void SeedClientApplicationData(ModelBuilder modelBuilder);
        void SeedRoleData(ModelBuilder modelBuilder);
        void SeedUserRoleData(ModelBuilder modelBuilder);
        void SeedRoleEntityData(ModelBuilder modelBuilder);
        void SeedAll(ModelBuilder modelBuilder);
    }
}