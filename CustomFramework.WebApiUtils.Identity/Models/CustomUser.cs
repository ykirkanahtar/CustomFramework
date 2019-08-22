using System;
using System.Collections.Generic;
using CustomFramework.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Models
{
    public class CustomUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }

        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int? DeleteUserId { get; set; }

        public DateTime LastTokenDate { get; set; }
        public DateTime LastLogOutDate { get; set; }
    }
}