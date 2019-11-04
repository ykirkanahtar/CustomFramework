using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CustomFramework.Data.Enums;
using System;
using CustomFramework.Data.Utils;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

namespace CustomFramework.WebApiUtils.Identity.Data.Repositories
{
    public class CustomUserRepository<TUser> : ICustomUserRepository<TUser>
    where TUser : CustomUser
    {
        private readonly DbContext _dbContext;

        public CustomUserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICustomList<TUser>> GetOnlineUsers(int sessionMinutes, int pageIndex, int pageSize, DateTime? DateTimeNowValue = null)
        {
            var query = (from u in _dbContext.Set<TUser>().AsNoTracking()
                         where u.Status == Status.Active
                         && SqlServerDbFunctionsExtensions.DateDiffMinute(EF.Functions, u.LastTokenDate, DateTimeNowValue ?? DateTime.Now) < sessionMinutes
                         && u.LastTokenDate > u.LastLogOutDate
                         select u);
            return await query.GetCustomListFromQueryAsync(new Paging(pageIndex, pageSize));
        }
    }
}