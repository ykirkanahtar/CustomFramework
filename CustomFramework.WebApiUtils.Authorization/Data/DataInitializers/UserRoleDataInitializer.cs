using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomFramework.WebApiUtils.Authorization.Data.DataInitializers
{
    public class UserRoleDataInitializer : BaseDataInitializer
    {
        public UserRoleDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var users = ConfigHelper.GetSection("Users");
            foreach (var section in users.GetChildren())
            {
                var userName = section.GetValue<string>("UserName");
                var userRoles = section.GetSection("Roles").Get<string[]>();

                var user = GetUsersByUserNameAsync(userName).Result[0];

                foreach (var roleName in userRoles)
                {

                    var role = GetRolesByNameAsync(roleName).Result[0];

                    if (GetUserRolesByUserIdAndRoleIdAsync(role.Id, user.Id).Result.Count > 0) continue;

                    var userRole = new UserRole()
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                    };

                    UnitOfWork.GetRepository<UserRole, int>().Add(userRole);
                }

                await UnitOfWork.SaveChangesAsync();
            }
        }

        private async Task<IList<UserRole>> GetUserRolesByUserIdAndRoleIdAsync(int roleId, int userId)
        {
            return await UnitOfWork.GetRepository<UserRole, int>()
                .GetAll(predicate: p => p.RoleId == roleId && p.UserId == userId).ToListAsync();
        }

        private async Task<IList<Role>> GetRolesByNameAsync(string name)
        {
            return await UnitOfWork.GetRepository<Role, int>()
                .GetAll(predicate: p => p.RoleName == name).ToListAsync();
        }

        private async Task<IList<User>> GetUsersByUserNameAsync(string userName)
        {
            return await UnitOfWork.GetRepository<User, int>()
                 .GetAll(predicate: p => p.UserName == userName).ToListAsync();
        }
    }
}
