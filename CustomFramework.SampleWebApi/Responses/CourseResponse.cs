namespace CustomFramework.SampleWebApi.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public int CourseNo { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public virtual TeacherResponse Teacher { get; set; }

    }
}
