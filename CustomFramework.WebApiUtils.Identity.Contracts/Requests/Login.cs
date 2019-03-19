using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class Login
    {
        [Required]
        public string ClientApplicationCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ClientApplicationPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}