using System.Collections.Generic;

namespace CustomFramework.SampleWebApi.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string CustomerNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<CurrentAccountResponse> CurrentAccounts { get; set; }
    }
}
