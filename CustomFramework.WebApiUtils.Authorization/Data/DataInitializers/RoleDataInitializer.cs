using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomFramework.WebApiUtils.Authorization.Data.DataInitializers
{
    public class RoleDataInitializer : BaseDataInitializer
    {
        public RoleDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var roles = ConfigHelper.GetSection("Roles");
            foreach (var section in roles.GetChildren())
            {
                var name = section.GetValue<string>("Name");

                if (GetRolesByNameAsync(name).Result.Count > 0) continue;

                var role = new Role
                {
                    RoleName = name,
                };

                UnitOfWork.GetRepository<Role, int>().Add(role);
                await UnitOfWork.SaveChangesAsync();
            }
        }

        private async Task<IList<Role>> GetRolesByNameAsync(string name)
        {
            return await UnitOfWork.GetRepository<Role, int>()
                 .GetAll(predicate: p => p.RoleName == name).ToListAsync();
        }
    }
}
