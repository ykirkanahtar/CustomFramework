using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserClaim : BaseModel<int>
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual Application Application { get; set; }
        public virtual Claim Claim { get; set; }
    }
}