namespace CustomFramework.WebApiUtils.Authorization.Request
{
    public class Login
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ClientApplicationCode { get; set; }
        public string ClientApplicationPassword { get; set; }
    }

}
