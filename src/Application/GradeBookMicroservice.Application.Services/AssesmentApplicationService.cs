using AutoMapper;
using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Teacher;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;

namespace GradeBookMicroservice.Application.Services;

public class AssesmentApplicationService(IRepository<Student, Guid> studentsRepository,
                                            IRepository<Grade, Guid> gradesRepository,
                                            IRepository<Teacher, Guid> teachersRepository,
                                            IRepository<Lesson, Guid> lessonsRepository,
                                            IMapper mapper) : IAssesmentApplicationService
{
    public async Task<GradeModel?> GradeStudentAsync(GradeStudentModel gradeInfromation)
    {
        var student = await studentsRepository.GetByIdAsync(gradeInfromation.StudentId);
        if (student is null)
            return null;
        var lesson = await lessonsRepository.GetByIdAsync(gradeInfromation.LessonId);
        if (lesson is null)
            return null;
        var teacher = lesson.Teacher;
        if (!student.AttendedLessons.Contains(lesson))
            return null;
        if (lesson.State != LessonStatus.Teached)
            return null;
        if (!teacher.TeachedLessons.Contains(lesson))
            return null;
        if (student.RecievedGrades.FirstOrDefault(gr => gr.Lesson == lesson && gr.Student == student) is not null)
            return null;
        teacher.GradeStudent(student, gradeInfromation.Mark, lesson, gradeInfromation.Comment);
        var grade = teacher.AssignedGrades.FirstOrDefault(gr => gr.Lesson == lesson && gr.Student == student);
        if(grade is null)
            return null;
        await gradesRepository.AddAsync(grade);
        await studentsRepository.UpdateAsync(student);
        await teachersRepository.UpdateAsync(teacher);
        return mapper.Map<GradeModel>(grade);
    }
}
