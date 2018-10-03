using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserManager : IBusinessManager<User, UserRequest, int>
    {
        Task<User> UpdateNameSurnameAsync(int id, UserNameSurnameUpdate nameSurname);
        Task<User> UpdateUserNameAsync(int id, string userName);
        Task<User> UpdatePasswordAsync(int id, string password);
        Task<User> UpdateEmailAsync(int id, string email);
        Task<User> LoginAsync(string userName, string password);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<ICustomList<User>> GetAllByKeywordAsync(string keyword, int pageIndex, int pageSize);
        Task<ICustomList<User>> GetAllLast10UserAsync();
        Task<ICustomList<User>> GetAllAsync();
        Task<ICustomList<User>> GetAllAsync(int pageIndex, int pageSize);

    }
}