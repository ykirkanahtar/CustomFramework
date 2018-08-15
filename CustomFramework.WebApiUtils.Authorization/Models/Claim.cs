using CustomFramework.Data.Models;
using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class Claim : BaseModel<int>
    {
        public string CustomClaim { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}