using CustomFramework.Data;
using CustomFramework.SampleWebApi.Data.Repositories;

namespace CustomFramework.SampleWebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWork
    {
        /*************Repositories************/
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        ITeacherRepository Teachers { get; }
        IStudentCourseRepository StudentCourses { get; }
        /*********End of Repositories*********/
    }
}