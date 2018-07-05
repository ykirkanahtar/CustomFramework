using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Contracts
{
    public class ApiRequest : IApiRequest
    {
        public ApiRequest(int applicationId, User user, ClientApplication clientApplication)
        {
            ApplicationId = applicationId;
            User = user;
            ClientApplication = clientApplication;
        }

        public int ApplicationId { get; set; }
        public User User { get; set; }
        public ClientApplication ClientApplication { get; set; }
    }
}