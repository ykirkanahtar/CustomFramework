using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<ICustomList<User>> GetAllLast10UserAsync();
        Task<ICustomList<User>> GetAllByKeywordAsync(string keyword, int pageIndex, int pageSize);
        Task<ICustomList<User>> GetAllAsync();
        Task<ICustomList<User>> GetAllAsync(int pageIndex, int pageSize);

    }
}