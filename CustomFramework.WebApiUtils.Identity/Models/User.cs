using System;
using CustomFramework.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
    }
}