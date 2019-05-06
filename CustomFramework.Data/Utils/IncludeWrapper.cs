using System;
using System.Linq;
using System.Linq.Expressions;
using CustomFramework.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public static class IncludeWrapper
    {
        public static ICustomQueryable<T> IncludeMultiple<T>(this ICustomQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query.Result = includes.Aggregate(query.Result,
                    (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
