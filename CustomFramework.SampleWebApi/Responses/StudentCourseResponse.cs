namespace CustomFramework.SampleWebApi.Responses
{
    public class StudentCourseResponse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual StudentResponse Student { get; set; }
        public virtual CourseResponse Course { get; set; }
    }
}
