using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.WebHost.Requests.Teacher;
using GradeBookMicroservice.WebHost.Responses.Teacher;

namespace GradeBookMicroservice.WebHost.Mapping;

public class TeacherMapping : Profile
{
    public TeacherMapping()
    {
        CreateMap<TeacherModel, TeacherShortResponse>();
        CreateMap<TeacherModel, TeacherDetailedResponse>();
        CreateMap<TeacherCreateRequest, CreateTeacherModel>();
    }

}
