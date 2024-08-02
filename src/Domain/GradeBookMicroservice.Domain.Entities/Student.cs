using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Student : Person
{
    private IEnumerable<Lesson> _lessons;
    private IEnumerable<Grade> _grades;
    private Group _group;
    public IReadOnlyCollection<Lesson> AttendedLessons => _lessons.ToImmutableList();
    public IReadOnlyCollection<Grade> RecievedGrades => _grades.ToImmutableList();
    public Group Group => _group;
    public Student(Guid id, PersonName name, Group group, IEnumerable<Lesson> lessons, IEnumerable<Grade> grades) : base(id, name)
    {
        _group = group;
        _lessons = lessons;
        _grades = grades;
        /*if(!group.Students.Contains(this))
            group.AddStudent(this);*/
    }
    public Student(PersonName name, Group group) : this(Guid.NewGuid(),name, group, [], [])
    {

    }
    public void AttendLesson(Lesson lesson)
    {
        if(lesson.State!=LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if(lesson.Group!=Group)
            throw new AnotherGroupLessonException(this, lesson.Group);
        if(_lessons.Contains(lesson))
            throw new DoubleVisitedLessonException(lesson,this);
        _lessons = _lessons.Append(lesson);

    }
    internal void GetGrade(Grade grade)
    {
        if(grade.Student!=this)
            throw new AnotherStudentGradeException(this, grade);
        if(!_lessons.Contains(grade.Lesson))
            throw new LessonNotVisitedException(grade.Lesson, this);
        if(_grades.Contains(grade))
            throw new DoubleGradeStudentLesson(grade.Lesson, this);
        _grades = _grades.Append(grade);
    }
    
}
