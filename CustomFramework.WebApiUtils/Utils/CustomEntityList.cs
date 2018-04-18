using System.Collections.Generic;

namespace CustomFramework.WebApiUtils.Utils
{
    public class CustomEntityList<T> : ICustomEntityList<T> where T : class
    {
        public IList<T> EntityList { get; set; }
        public int Count { get; set; }
    }
}