namespace CustomFramework.SampleWebApi.Requests
{
    public class CustomerRequest
    {
        public string CustomerNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CurrentAccountRequest CurrentAccount { get; set; }
    }
}
