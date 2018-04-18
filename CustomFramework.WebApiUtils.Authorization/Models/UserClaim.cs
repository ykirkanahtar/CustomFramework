using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserClaim : BaseModel<int>
    {
        public int UserId { get; set; }
        public int ClaimId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Claim Claim { get; set; }
    }
}