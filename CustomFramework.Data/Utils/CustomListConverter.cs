using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public static class CustomListConverter
    {
        public static async Task<ICustomList<T>> ToCustomList<T>(this ICustomQueryable<T> query)
        where T : class
        {
            return new CustomList<T>
            {
                ResultList = await query.Result.ToListAsync(),
                Count = query.Count,
            };
        }

        public static async Task<ICustomList<T>> ToCustomList<T>(this IQueryable<T> result) where T : class
        {
            var list = await result.ToListAsync();
            return new CustomList<T>
            {
                Count = list.Count,
                ResultList = list
            };
        }
    }
}