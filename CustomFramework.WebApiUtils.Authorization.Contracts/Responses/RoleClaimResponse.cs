namespace CustomFramework.WebApiUtils.Authorization.Contracts.Responses
{
    public class RoleClaimResponse
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public int ClaimId { get; set; }
    }
}