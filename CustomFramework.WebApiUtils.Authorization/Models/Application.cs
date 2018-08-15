using System.Collections.Generic;
using CustomFramework.Data;
using CustomFramework.Data.Models;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class Application : BaseModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserClaim> UserClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserEntityClaim> UserEntityClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<RoleEntityClaim> RoleEntityClaims { get; set; }

    }
}