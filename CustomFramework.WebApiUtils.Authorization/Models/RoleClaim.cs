using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class RoleClaim : BaseModel<int>
    {
        public int RoleId { get; set; }
        public int ClaimId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

        [JsonIgnore]
        public Claim Claim { get; set; }
    }
}