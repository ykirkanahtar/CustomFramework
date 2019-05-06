namespace CustomFramework.WebApiUtils.Authorization.Contracts.Requests
{
    public class Login
    {
        public int ApplicationId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string ClientApplicationCode { get; set; }
        public string ClientApplicationPassword { get; set; }
    }

}
