using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Student(Guid id, PersonName name, Group group, IEnumerable<Lesson> lessons, IEnumerable<Grade> grades) : Person(id,name)
{
    private IEnumerable<Lesson> _lessons = lessons;
    private IEnumerable<Grade> _grades = grades;
    private Group _group = group;
    public IReadOnlyCollection<Lesson> AttendedLessons => _lessons.ToImmutableList();
    public IReadOnlyCollection<Grade> RecievedGrades => _grades.ToImmutableList();
    public Group Group => _group;
    public Student(PersonName name, Group group) : this(Guid.NewGuid(),name, group, [], [])
    {

    }
    public void AttendLesson(Lesson lesson)
    {
        if(lesson.State!=LessonStatus.Teached)
            throw new InvalidOperationException("Can not visit not teached lesson");
        if(lesson.Group!=Group)
            throw new InvalidOperationException("Can not visit lesson in different group");
        if(_lessons.Contains(lesson))
            throw new InvalidOperationException("Can not visit lesson twice");
        _lessons = _lessons.Append(lesson);

    }
    internal void GetGrade(Grade grade)
    {
        if(grade.Student!=this)
            throw new InvalidOperationException("Can not get grade from different student");
        if(!_lessons.Contains(grade.Lesson))
            throw new InvalidOperationException("Can not receive grade for not visited lesson");
        if(grade.Lesson.State!=LessonStatus.Teached)
            throw new InvalidOperationException("Can not receive grade for not teached lesson");
        if(_grades.Contains(grade))
            throw new InvalidOperationException("Can not receive grade twice");
        _grades = _grades.Append(grade);
    }
    
}
