using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class ClientApplicationUtil : BaseModel<int>
    {
        public string SpecialValue { get; set; }
        public int ClientApplicationId { get; set; }

        [JsonIgnore]
        public ClientApplication ClientApplication { get; set; }
    }
}
