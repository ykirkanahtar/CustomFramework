using CustomFramework.Authorization.Enums;

namespace CustomFramework.WebApiUtils.Authorization.Response
{
    public class ClaimResponse
    {
        public int Id { get; set; }
        public CustomClaim CustomCLaim { get; set; }
    }
}
