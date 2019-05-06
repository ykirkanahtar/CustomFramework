namespace CustomFramework.WebApiUtils.Authorization.Contracts.Requests
{
    public class UserClaimRequest
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }
    }
}