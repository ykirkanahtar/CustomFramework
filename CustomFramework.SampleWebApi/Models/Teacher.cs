using System.Collections.Generic;
using CustomFramework.Data;

namespace CustomFramework.SampleWebApi.Models
{
    public class Teacher : BaseModel<int>
    {
        public int TeacherNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
