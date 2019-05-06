using CustomFramework.Data.Models;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserEntityClaim : BaseModel<int>
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        public virtual User User { get; set; }
        public virtual Application Application { get; set; }

    }
}