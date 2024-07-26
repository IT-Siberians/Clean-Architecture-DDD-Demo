using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Application.Services.Base;

public interface ILessonsApplicationService
{
    Task<IEnumerable<LessonModel>> GetAllLessonsAsync();
    Task<Lesson?> GetLessonByIdAsync(Guid id);
    Task<LessonModel?> CreateLessonAsync(CreateLessonModel lessonInfo)
    Task UpdateLessonAsync(LessonModel lesson);
    Task DeleteLessonAsync(Guid id);
}
