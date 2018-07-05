using CustomFramework.Data;

namespace CustomFramework.SampleWebApi.Models
{
    public class School : BaseModel<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
