using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public static class CustomListConverter
    {
        public static async Task<ICustomList<T>> ToCustomList<T>(this ICustomQueryable<T> query, Paging paging)
        where T : class
        {
            return new CustomList<T>
            {
                Result = await query.Result.ToListAsync(),
                TotalCount = query.TotalCount,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = query.TotalCount / paging.PageSize
            };
        }

        public static async Task<ICustomList<T>> ToCustomList<T>(this IQueryable<T> result, Paging paging) where T : class
        {
            var list = await result.ToListAsync();
            return new CustomList<T>
            {
                Result = list,
                TotalCount = list.Count,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = list.Count / paging.PageSize
            };
        }

        public static ICustomList<T> ToCustomList<T>(this IList<T> result, Paging paging) where T : class
        {
            return new CustomList<T>
            {
                Result = result,
                TotalCount = result.Count,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = result.Count / paging.PageSize
            };
        }
    }
}