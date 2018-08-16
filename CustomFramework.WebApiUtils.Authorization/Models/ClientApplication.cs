using CustomFramework.Data.Models;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class ClientApplication : BaseModel<int>
    {
        public string ClientApplicationName { get; set; }
        public string ClientApplicationCode { get; set; }
        public string ClientApplicationPassword { get; set; }

        [JsonIgnore]
        public virtual ClientApplicationUtil ClientApplicationUtil { get; set; }
    }
}
