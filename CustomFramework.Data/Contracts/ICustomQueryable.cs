using System.Linq;

namespace CustomFramework.Data.Contracts
{
    public interface ICustomQueryable<T> where T : class
    {
        int Count { get; set; }
        IQueryable<T> Result { get; set; }
    }
}