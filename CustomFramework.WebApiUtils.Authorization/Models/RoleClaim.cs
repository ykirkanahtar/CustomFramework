using CustomFramework.Data.Models;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class RoleClaim : BaseModel<int>
    {
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public int ClaimId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Application Application { get; set; }
        public virtual Claim Claim { get; set; }
    }
}