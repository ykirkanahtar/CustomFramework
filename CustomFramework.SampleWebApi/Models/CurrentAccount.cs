using CustomFramework.Data;

namespace CustomFramework.SampleWebApi.Models
{
    public class CurrentAccount : BaseModel<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
