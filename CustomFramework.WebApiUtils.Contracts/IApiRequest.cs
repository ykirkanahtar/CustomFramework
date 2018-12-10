namespace CustomFramework.WebApiUtils.Contracts
{
    public interface IApiRequest
    {
        int ApplicationId { get; set; }
        int UserId { get; set; }
        int ClientApplicationId { get; set; }
    }
}