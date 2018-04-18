using CustomFramework.Authorization;
using CustomFramework.Authorization.Enums;

namespace CustomFramework.WebApiUtils.Authorization.Request
{
    public class RoleEntityClaimRequest
    {
        public int RoleId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}