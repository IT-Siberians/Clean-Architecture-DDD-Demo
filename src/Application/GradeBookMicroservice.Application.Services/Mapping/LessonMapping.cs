using AutoMapper;
using GradeBookMicroservice.Application.Models.Lesson;
using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Application.Services.Mapping;

public class LessonMapping : Profile
{
    public LessonMapping()
    {
        CreateMap<Lesson, LessonModel>().ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic.Topic));
    }

}
