using AutoMapper;
using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.WebHost.Requests.Student;
using GradeBookMicroservice.WebHost.Responses.Student;

namespace GradeBookMicroservice.WebHost.Mapping;

public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<CreateStudentRequest, CreateStudentModel>();
        CreateMap<StudentModel, StudentShortResponse>();
        CreateMap<StudentModel, StudentDetailedResponse>();
        CreateMap<VisitLessonRequest, VisitLessonModel>();
    }
}
