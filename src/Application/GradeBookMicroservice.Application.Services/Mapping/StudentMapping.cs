using AutoMapper;
using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Application.Services.Mapping;

public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
    }

}
