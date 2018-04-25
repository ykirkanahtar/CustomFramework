using System.Linq;

namespace CustomFramework.Data.Contracts
{
    public class CustomQueryable<T> : ICustomQueryable<T> where T : class
    {
        public int Count { get; set; }
        public IQueryable<T> Result { get; set; }
    }
}