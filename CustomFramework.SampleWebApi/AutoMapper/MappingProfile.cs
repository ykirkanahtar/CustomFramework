using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.SampleWebApi.Responses;
using CustomFramework.WebApiUtils.Authorization.AutoMapper;

namespace CustomFramework.SampleWebApi.AutoMapper
{
    public class MappingProfile : AuthorizationMappingProfile
    {
        public MappingProfile()
        {
            Map();

            /*************EntitiesMapping*************/
            CreateMap<Student, StudentResponse>();
            CreateMap<StudentRequest, Student>();
            CreateMap<Course, CourseResponse>();
            CreateMap<CourseRequest, Course>();
            CreateMap<Teacher, TeacherResponse>();
            CreateMap<TeacherRequest, Teacher>();
            CreateMap<StudentCourse, StudentCourseResponse>();
            CreateMap<StudentCourseRequest, StudentCourse>();
            /*********End of Entities Mapping*********/
        }
    }
}