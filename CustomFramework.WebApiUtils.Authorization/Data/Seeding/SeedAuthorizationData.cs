using System.Collections.Generic;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Seeding
{
    public class SeedAuthorizationData : ISeedAuthorizationData
    {
        private static int ClientApplicationUtilId { get; set; }
        private static int UserUtilId { get; set; }

        public SeedAuthorizationData()
        {
            ClientApplications = new List<ClientApplication>();
            RoleEntityClaims = new List<RoleEntityClaim>();
            Roles = new List<Role>();
            Users = new List<User>();
            ClientApplicationUtilId = 1;
            UserUtilId = 1;
        }

        public IList<ClientApplication> ClientApplications { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<User> Users { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<RoleEntityClaim> RoleEntityClaims { get; set; }

        public void SeedUserData(ModelBuilder modelBuilder)
        {
            foreach (var user in Users)
            {
                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(user.Password, salt
                    , AuthorizationUtilConstants.IterationCountForHashing);

                var userUtil = new UserUtil
                {
                    Id = UserUtilId,
                    UserId = user.Id,
                    SpecialValue = salt,
                };

                user.Password = hashPassword;

                SeedDataUtil.SetCommonFields<User, int>(user);
                SeedDataUtil.SetCommonFields<UserUtil, int>(userUtil);

                modelBuilder.Entity<User>()
                    .HasData(user);

                modelBuilder.Entity<UserUtil>()
                    .HasData(userUtil);

                UserUtilId++;
            }
        }

        public void SeedClientApplicationData(ModelBuilder modelBuilder)
        {
            foreach (var clientApplication in ClientApplications)
            {
                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(clientApplication.ClientApplicationPassword, salt
                    , AuthorizationUtilConstants.IterationCountForHashing);
                var clientApplicationUtil = new ClientApplicationUtil()
                {
                    Id = ClientApplicationUtilId,
                    ClientApplicationId = clientApplication.Id,
                    SpecialValue = salt,
                };

                clientApplication.ClientApplicationPassword = hashPassword;

                SeedDataUtil.SetCommonFields<ClientApplication, int>(clientApplication);
                SeedDataUtil.SetCommonFields<ClientApplicationUtil, int>(clientApplicationUtil);

                modelBuilder.Entity<ClientApplication>()
                    .HasData(clientApplication);

                modelBuilder.Entity<ClientApplicationUtil>()
                    .HasData(clientApplicationUtil);

                ClientApplicationUtilId++;
            }
        }

        public void SeedRoleData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Role, int>(modelBuilder, Roles);
        }

        public void SeedUserRoleData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<UserRole, int>(modelBuilder, UserRoles);
        }

        public void SeedRoleEntityData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<RoleEntityClaim, int>(modelBuilder, RoleEntityClaims);
        }

        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedUserData(modelBuilder);
            SeedClientApplicationData(modelBuilder);
            SeedRoleData(modelBuilder);
            SeedUserRoleData(modelBuilder);
            SeedRoleEntityData(modelBuilder);
        }
    }
}