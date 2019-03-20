using CustomFramework.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Models
{
    public class Role : IdentityRole<int>
    {
        public Status Status { get; set; }
    }
}