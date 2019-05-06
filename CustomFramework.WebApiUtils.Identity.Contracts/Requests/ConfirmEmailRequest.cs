using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ConfirmEmailRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}