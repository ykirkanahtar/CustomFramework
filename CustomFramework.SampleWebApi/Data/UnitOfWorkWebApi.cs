using CustomFramework.Data;
using CustomFramework.SampleWebApi.Data.Repositories;

namespace CustomFramework.SampleWebApi.Data
{
    public class UnitOfWorkWebApi : UnitOfWork<ApplicationContext>, IUnitOfWorkWebApi
    {
        public UnitOfWorkWebApi(ApplicationContext context) : base(context)
        {
            /*************Instances************/
            Students = new StudentRepository(context);
            Courses = new CourseRepository(context);
            Teachers = new TeacherRepository(context);
            StudentCourses = new StudentCourseRepository(context);
            /*********End of Instances*********/
        }

        /*************Repositories************/
        public IStudentRepository Students { get; }
        public ICourseRepository Courses { get; }
        public ITeacherRepository Teachers { get; }
        public IStudentCourseRepository StudentCourses { get; }
        /*********End of Repositories*********/
    }
}