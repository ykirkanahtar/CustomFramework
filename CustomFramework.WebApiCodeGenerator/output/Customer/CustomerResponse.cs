namespace CustomFramework.SampleWebApi.Responses
{
    public class Customer
    {
        public int Id { get; set; }  
	public string CustomerNo { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }

	public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; }

    }
}
