using GradeBookMicroservice.Application.Models.Lesson;

namespace GradeBookMicroservice.Application.Services.Base;

public interface ILessonsApplicationService
{
    Task<IEnumerable<LessonModel>> GetAllLessonsAsync();
    Task<LessonModel?> GetLessonByIdAsync(Guid id);
    Task<LessonModel?> CreateLessonAsync(CreateLessonModel lessonInfo);
    Task UpdateLessonAsync(LessonModel lesson);
    Task DeleteLessonAsync(Guid id);
}
