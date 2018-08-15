using CustomFramework.Data.Models;
using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class Role : BaseModel<int>
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public virtual ICollection<RoleEntityClaim> RoleEntityClaims { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}