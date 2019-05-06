using System;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class CustomRoleRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}