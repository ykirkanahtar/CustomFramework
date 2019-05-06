using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ClientApplicationRequest
    {
        [Required]
        [MaxLength(6)]
        [DataType(DataType.Text)]
        public string ClientApplicationName { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public string ClientApplicationCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ClientApplicationPassword { get; set; }

    }
}