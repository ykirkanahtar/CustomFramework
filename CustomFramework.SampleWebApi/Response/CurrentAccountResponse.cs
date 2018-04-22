namespace CustomFramework.SampleWebApi.Response
{
    public class CurrentAccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }

        public virtual CustomerResponse Customer { get; set; }
    }
}
