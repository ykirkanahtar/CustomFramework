namespace CustomFramework.WebApiUtils.Authorization.Contracts.Requests
{
    public class UserRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}