namespace CustomFramework.WebApiUtils.Contracts
{
    public class ApiRequest : IApiRequest
    {
        public ApiRequest(int applicationId, int userId, int clientApplicationId)
        {
            ApplicationId = applicationId;
            UserId = userId;
            ClientApplicationId = clientApplicationId;
        }

        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int ClientApplicationId { get; set; }
    }
}