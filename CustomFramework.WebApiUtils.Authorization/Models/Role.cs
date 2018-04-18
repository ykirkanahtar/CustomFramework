using System.Collections.Generic;
using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class Role : BaseModel<int>
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public IList<RoleClaim> RoleClaims { get; set; }

        [JsonIgnore]
        public IList<RoleEntityClaim> RoleEntityClaims { get; set; }

        [JsonIgnore]
        public IList<UserRole> UserRoles { get; set; }
    }
}