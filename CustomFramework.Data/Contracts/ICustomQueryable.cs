using System.Linq;

namespace CustomFramework.Data.Contracts
{
    public interface ICustomQueryable<T> where T : class
    {
        int TotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int PageCount { get; set; }
        IQueryable<T> Result { get; set; }
    }
}