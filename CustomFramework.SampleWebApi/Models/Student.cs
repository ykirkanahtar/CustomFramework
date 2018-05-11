using System.Collections.Generic;
using CustomFramework.Data;

namespace CustomFramework.SampleWebApi.Models
{
    public class Student : BaseModel<int>
    {
        public int StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
