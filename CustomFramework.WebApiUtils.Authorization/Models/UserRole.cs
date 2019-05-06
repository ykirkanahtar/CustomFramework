using CustomFramework.Data.Models;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserRole : BaseModel<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}