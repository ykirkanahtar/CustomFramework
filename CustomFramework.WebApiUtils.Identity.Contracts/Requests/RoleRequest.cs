using System;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class RoleRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}