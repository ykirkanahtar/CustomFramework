using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;

namespace CustomFramework.WebApiUtils.Identity.Extensions
{
    public class IdentityModel
    {
        public IdentityModel()
        {
            Token = new Token();
            EmailConfig = new EmailConfig();
        }

        public bool SendConfirmationEmail { get; set; }
        public string SenderEmailAddress { get; set; }
        public string AppName { get; set; }
        public Token Token { get; set; }
        public EmailConfig EmailConfig { get; set; }

        public int GeneratedPasswordLength { get; set; }
    }
}