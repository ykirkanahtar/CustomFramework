using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Identity.Models
{
    public class CustomUserWithRoles
    {
        public CustomUserWithRoles(CustomUser user, IList<string> roles)
        {
            User = user;
            Roles = roles;
        }

        public CustomUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}