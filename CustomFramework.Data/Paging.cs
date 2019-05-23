using System;

namespace CustomFramework.Data
{
    public class Paging : IPaging
    {
        public Paging(int pageIndex, int pageSize)
        {
            if (pageSize == 0) throw new ArgumentException("PageSizeCanNotBeZero");
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}