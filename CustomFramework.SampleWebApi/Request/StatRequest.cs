namespace CustomFramework.SampleWebApi.Request
{
    public class StatRequest
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public decimal Goal { get; set; }
        public decimal OwnGoal { get; set; }
        public decimal Assist { get; set; }
    }
}
