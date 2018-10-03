namespace CustomFramework.WebApiUtils.Authorization.Requests
{
    public class UserEntityClaimRequest
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}