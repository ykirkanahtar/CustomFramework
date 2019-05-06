using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Constants;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Seeding
{
    public class SeedAuthorizationData : ISeedAuthorizationData
    {
        private static int ClientApplicationUtilId { get; set; }
        private static int UserUtilId { get; set; }
        private static int LoggedUserId { get; set; }

        public SeedAuthorizationData()
        {
            ClientApplications = new List<ClientApplication>();
            RoleEntityClaims = new List<RoleEntityClaim>();
            Roles = new List<Role>();
            Users = new List<User>();
            ApplicationUsers = new List<ApplicationUser>();
            Applications = new List<Application>();
            ClientApplicationUtilId = 1;
            UserUtilId = 1;
            LoggedUserId = 1;
        }

        public IList<Application> Applications { get; set; }
        public IList<ClientApplication> ClientApplications { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<User> Users { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<ApplicationUser> ApplicationUsers { get; set; }
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

                SeedDataUtil.SetCommonFields<User, int>(user, LoggedUserId);
                SeedDataUtil.SetCommonFields<UserUtil, int>(userUtil, LoggedUserId);

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

                SeedDataUtil.SetCommonFields<ClientApplication, int>(clientApplication, LoggedUserId);
                SeedDataUtil.SetCommonFields<ClientApplicationUtil, int>(clientApplicationUtil, LoggedUserId);

                modelBuilder.Entity<ClientApplication>()
                    .HasData(clientApplication);

                modelBuilder.Entity<ClientApplicationUtil>()
                    .HasData(clientApplicationUtil);

                ClientApplicationUtilId++;
            }
        }

        public void SeedRoleData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Role, int>(modelBuilder, Roles, LoggedUserId);
        }

        public void SeedUserRoleData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<UserRole, int>(modelBuilder, UserRoles, LoggedUserId);
        }

        public void SeedRoleEntityData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<RoleEntityClaim, int>(modelBuilder, RoleEntityClaims, LoggedUserId);
        }

        public void SeedApplicationData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Application, int>(modelBuilder, Applications, LoggedUserId);
        }

        public void SeedApplicationUsersData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<ApplicationUser, int>(modelBuilder, ApplicationUsers, LoggedUserId);
        }

        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedUserData(modelBuilder);
            SeedClientApplicationData(modelBuilder);
            SeedRoleData(modelBuilder);
            SeedUserRoleData(modelBuilder);
            SeedRoleEntityData(modelBuilder);
            SeedApplicationData(modelBuilder);
            SeedApplicationUsersData(modelBuilder);
        }
    }
}