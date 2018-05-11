using System.Collections.Generic;
using CustomFramework.Data;

namespace CustomFramework.SampleWebApi.Models
{
    public class Course : BaseModel<int>
    {
        public int CourseNo { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
