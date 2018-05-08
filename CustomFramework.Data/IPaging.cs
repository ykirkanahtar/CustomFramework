namespace CustomFramework.Data
{
    public interface IPaging
    {
        int PageIndex { get; }
        int PageSize { get; }
    }
}