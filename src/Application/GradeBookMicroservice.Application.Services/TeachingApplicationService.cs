using GradeBookMicroservice.Application.Models.Teacher;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;

namespace GradeBookMicroservice.Application.Services;

public class TeachingApplicationService(IRepository<Teacher, Guid> teachersRepository, 
                                            IRepository<Lesson, Guid> lessonsRepository) : ITeachingApplicationService
{
    public async Task<bool> TeachLessonAsync(TeachLessonModel teachingInfo)
    {
        var teacher = await teachersRepository.GetByIdAsync(teachingInfo.TeacherId);
        if(teacher is null)
            return false;
        var lesson = await lessonsRepository.GetByIdAsync(teachingInfo.LessonId);
        if(lesson is null)
            return false;
        if(lesson.State != LessonStatus.New)
            return false;
        if(teacher.TeachedLessons.Contains(lesson))
            return false;
        teacher.TeachLesson(lesson);
        await teachersRepository.UpdateAsync(teacher);
        await lessonsRepository.UpdateAsync(lesson);
        return true;
    
    }
}
