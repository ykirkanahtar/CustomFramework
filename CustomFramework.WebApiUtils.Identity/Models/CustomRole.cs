using CustomFramework.Data.Contracts;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Models
{
    public class CustomRole : IdentityRole<int>
    {
        public Status Status { get; set; }
    }
}