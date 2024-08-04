using System.Collections.Immutable;
using GradebookMicroservice.Common.Enumes;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Teacher(PersonName name) : Person(Guid.NewGuid(), name)
{
    private readonly ICollection<Lesson> _lessons = [];
    private readonly ICollection<Grade> _grades = [];
    public IReadOnlyCollection<Lesson> TeachedLessons => _lessons.Where(lesson => lesson.State == LessonStatus.Teached).ToList().AsReadOnly();
    public IReadOnlyCollection<Lesson> SchedulledLessons => _lessons.Where(lesson => lesson.State == LessonStatus.New).ToList().AsReadOnly();
    public IReadOnlyCollection<Grade> AssignedGrades => [.._grades];

    public void TeachLesson(Lesson lesson)
    {
        if (lesson.State == LessonStatus.Teached)
            throw new LessonAlreadyTeachedException(lesson);
        if (TeachedLessons.Contains(lesson))
            throw new DoubleTeachedLessonException(lesson, this);
        lesson.Teach();
        if (!_lessons.Contains(lesson))
            _lessons.Add(lesson);
    }
    public void GradeStudent(Student student, Mark mark, Lesson lesson, string? comment = null)
    {
        if (lesson.State != LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if (!_lessons.Contains(lesson))
            throw new AnotherTeacherLessonGradedException(lesson, this);
        if (_grades.FirstOrDefault(gr => gr.Student == student && gr.Lesson == lesson) is not null)
            throw new DoubleGradeStudentLesson(lesson, student);
        var grade = new Grade(this, student, lesson, DateTime.Now, mark, comment);
        student.GetGrade(grade);
        _grades.Add(grade);
    }
    internal void ScheduleLesson(Lesson lesson)
    {
        if (lesson.State != LessonStatus.New)
            throw new LessonAlreadyTeachedException(lesson);
        if (!_lessons.Contains(lesson))
            _lessons.Add(lesson);

    }

}
