namespace CustomFramework.SampleWebApi.Requests
{
    public class Customer
    {
	public string CustomerNo { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }

	public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; }

    }
}
