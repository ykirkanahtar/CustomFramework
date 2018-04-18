namespace CustomFramework.Data
{
    public class SkipTake : ISkipTake
    {
        public SkipTake(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}