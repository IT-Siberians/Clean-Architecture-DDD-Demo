using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Student : Person
{
    private readonly ICollection<Lesson> _lessons = [];
    private readonly ICollection<Grade> _grades = [];
    public IReadOnlyCollection<Lesson> AttendedLessons => [.. _lessons];
    public IReadOnlyCollection<Grade> RecievedGrades => [.. _grades];
    public Group Group { get; protected set; }
    protected Student(Guid id, PersonName name, Group group) : base(id, name)
    {
        Group = group;
        if (!group.Students.Contains(this))
            group.AddStudent(this);
    }
    public Student(PersonName name, Group group) : this(Guid.NewGuid(), name, group)
    {

    }
    protected Student(Guid id, PersonName name) : base(id, name)
    {

    }
    public void AttendLesson(Lesson lesson)
    {
        if (lesson.State != LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if (lesson.Group != Group)
            throw new AnotherGroupLessonException(this, lesson.Group);
        if (_lessons.Contains(lesson))
            throw new DoubleVisitedLessonException(lesson, this);
        _lessons.Add(lesson);

    }
    internal void GetGrade(Grade grade)
    {
        if (grade.Student != this)
            throw new AnotherStudentGradeException(this, grade);
        if (!_lessons.Contains(grade.Lesson))
            throw new LessonNotVisitedException(grade.Lesson, this);
        if (_grades.Contains(grade))
            throw new DoubleGradeStudentLesson(grade.Lesson, this);
        _grades.Add(grade);
    }

}
