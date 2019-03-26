using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class UserAddToRoleRequest
    {
        public int UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}