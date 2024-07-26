using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;
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
    }
}
