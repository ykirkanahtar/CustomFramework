using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Responses
{
    public class CustomUserWithRolesResponse
    {
        public CustomUserResponse User { get; set; }
        public IList<string> Roles { get; set; }
    }
}