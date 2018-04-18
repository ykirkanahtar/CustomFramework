using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class UserUtil : BaseModel<int>
    {
        public string SpecialValue { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
