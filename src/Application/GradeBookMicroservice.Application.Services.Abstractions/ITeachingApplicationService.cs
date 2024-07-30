using GradeBookMicroservice.Application.Models.Teacher;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface ITeachingApplicationService
{
    Task<bool> TeachLesson(TeachLessonModel teachingInfo);

}
