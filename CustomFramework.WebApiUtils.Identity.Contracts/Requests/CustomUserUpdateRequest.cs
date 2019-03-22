using System;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class CustomUserUpdateRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}