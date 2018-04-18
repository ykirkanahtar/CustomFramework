using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Utils
{
    public interface ICustomEntityList<T> where T : class
    {
        int Count { get; set; }
        IList<T> EntityList { get; set; }
    }
}