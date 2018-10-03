using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserUtilManager : IBusinessManager<UserUtil, UserUtilRequest, int>
                                        , IBusinessManagerUpdate<UserUtil, UserUtilUpdateRequest, int>
    {
        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}