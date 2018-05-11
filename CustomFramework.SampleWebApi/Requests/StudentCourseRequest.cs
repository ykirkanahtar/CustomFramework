namespace CustomFramework.SampleWebApi.Requests
{
    public class StudentCourseRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual StudentRequest Student { get; set; }
        public virtual CourseRequest Course { get; set; }

    }
}
