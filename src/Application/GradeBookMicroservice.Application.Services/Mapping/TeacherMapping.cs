using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Application.Services.Mapping;

public class TeacherMapping : Profile
{
    public TeacherMapping()
    {
        CreateMap<Teacher, TeacherModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
    }

}
