namespace CustomFramework.SampleWebApi.Models
{
    public class Customer : BaseModel<int>
    {
	public string CustomerNo { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }

	public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; }

    }
}
