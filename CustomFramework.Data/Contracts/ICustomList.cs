using System.Collections.Generic;

namespace CustomFramework.Data.Contracts
{
    public interface ICustomList<T> where T : class
    {
        int Count { get; set; }
        IList<T> ResultList { get; set; }
    }
}