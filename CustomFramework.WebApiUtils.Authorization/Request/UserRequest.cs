namespace CustomFramework.WebApiUtils.Authorization.Request
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
