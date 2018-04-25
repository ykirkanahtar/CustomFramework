using System.Collections.Generic;

namespace CustomFramework.Data.Contracts
{
    public class CustomList<T> : ICustomList<T> where T : class
    {
        public int Count { get; set; }
        public IList<T> ResultList { get; set; }
    }
}