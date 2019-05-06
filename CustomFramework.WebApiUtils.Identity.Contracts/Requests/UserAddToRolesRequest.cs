using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class UserAddToRolesRequest
    {
        public int UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}