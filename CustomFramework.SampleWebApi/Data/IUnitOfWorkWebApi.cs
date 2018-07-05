using CustomFramework.Data;
using CustomFramework.SampleWebApi.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Data.Repositories;

namespace CustomFramework.SampleWebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWork
    {
        /*************Repositories************/
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        ITeacherRepository Teachers { get; }
        IStudentCourseRepository StudentCourses { get; }
        ISchoolRepository Schools { get; }
        IApplicationRepository Applications { get; }
        /*********End of Repositories*********/
    }
}