using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class ApplicationUser : BaseModel<int>
    {
        public int UserId { get; set; }
        public int ApplicationId { get; set; }

        public virtual User User { get; set; }
        public virtual Application Application { get; set; }
    }
}