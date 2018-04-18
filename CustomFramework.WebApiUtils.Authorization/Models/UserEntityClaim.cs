using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserEntityClaim : BaseModel<int>
    {
        public int UserId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}