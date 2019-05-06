namespace CustomFramework.Data
{
    public class Paging : IPaging
    {
        public Paging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}