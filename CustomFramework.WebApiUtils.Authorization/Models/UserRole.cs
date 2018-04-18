using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserRole : BaseModel<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }
}