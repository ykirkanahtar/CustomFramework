using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserEntityClaimRepository : IRepository<UserEntityClaim, int>
    {
        Task<UserEntityClaim> GetByUserIdAndEntityAsync(int userId, string entity);
        Task<ICustomList<UserEntityClaim>> UserIsAuthorizedForEntityClaimAsync(int userId, string entity, Crud crud);
        Task<ICustomList<UserEntityClaim>> GetAllByEntityAsync(string entity);
        Task<ICustomList<UserEntityClaim>> GetAllByUserIdAsync(int userId);

    }
}