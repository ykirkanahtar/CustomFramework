using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserUtilManager : IBusinessManager<UserUtil, UserUtilRequest, int>
                                        , IBusinessManagerUpdate<UserUtil, UserUtilUpdateRequest, int>
    {
        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}