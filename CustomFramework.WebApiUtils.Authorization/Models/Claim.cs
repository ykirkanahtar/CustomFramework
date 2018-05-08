using System.Collections.Generic;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class Claim : BaseModel<int>
    {
        public string CustomClaim { get; set; }

        [JsonIgnore]
        public IList<RoleClaim> RoleClaims { get; set; }

        [JsonIgnore]
        public IList<UserClaim> UserClaims { get; set; }
    }
}