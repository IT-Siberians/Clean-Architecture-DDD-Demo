using AutoMapper;
using GradeBookMicroservice.Application.Models.Lesson;
using GradeBookMicroservice.WebHost.Requests.Lesson;
using GradeBookMicroservice.WebHost.Responses.Lesson;

namespace GradeBookMicroservice.WebHost.Mapping;

public class LessonMapping : Profile
{
    public LessonMapping()
    {
        CreateMap<LessonModel, LessonShortResponse>();
        CreateMap<LessonModel, LessonDetailedResponse>();
        CreateMap<CreateLessonRequest, CreateLessonModel>();
    }

}
