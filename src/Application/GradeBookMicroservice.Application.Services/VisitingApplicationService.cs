using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Repositories.Abstractions;

namespace GradeBookMicroservice.Application.Services;

public class VisitingApplicationService(IRepository<Lesson, Guid> lessonsRepository,
                                         IRepository<Student, Guid> studentsRepository) : IVisitingApplicationService
{
    public async Task<bool> VisitLessonAsync(VisitLessonModel visitInformation)
    {
        var student = await studentsRepository.GetByIdAsync(visitInformation.StudentId);
        if (student is null)
            return false;
        var lesson = await lessonsRepository.GetByIdAsync(visitInformation.LessonId);
        if (lesson is null)
            return false;
       /* if (student.AttendedLessons.Contains(lesson))
            return false;*/
        if (lesson.State != LessonStatus.Teached)
            return false;
        student.AttendLesson(lesson);
        await studentsRepository.UpdateAsync(student);
        await lessonsRepository.UpdateAsync(lesson);
        return true;
    }
}
