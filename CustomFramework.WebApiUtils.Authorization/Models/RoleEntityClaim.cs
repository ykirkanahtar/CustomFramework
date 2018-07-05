using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Models
{
    public class RoleEntityClaim : BaseModel<int>
    {
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        public virtual Role Role { get; set; }
        public virtual Application Application { get; set; }
    }
}