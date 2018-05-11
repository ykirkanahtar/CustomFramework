using System;
using System.Collections.Generic;
using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class User : BaseModel<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string EmailConfirmCode { get; set; }
        public int AccessFailedCount { get; set; }
        public bool Lockout { get; set; }
        public DateTime? LockoutEndDateTime { get; set; }

        [JsonIgnore]
        public UserUtil UserUtil { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserClaim> UserClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserEntityClaim> UserEntityClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}

