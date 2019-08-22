using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Identity.Models;
using System;
using CustomFramework.Data.Contracts;

namespace CustomFramework.WebApiUtils.Identity.Data.Repositories
{
    public interface ICustomUserRepository<TUser>
        where TUser : CustomUser
    {
        Task<ICustomList<TUser>> GetOnlineUsers(int sessionMinutes, int pageIndex, int pageSize, DateTime? DateTimeNowValue = null);
    }
}