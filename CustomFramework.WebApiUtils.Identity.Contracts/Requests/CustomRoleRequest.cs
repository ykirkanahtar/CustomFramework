using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class CustomRoleRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(Name))]        
        public string Name { get; set; }
    }
}