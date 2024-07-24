using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Student(Guid id, PersonName name, Group group, IEnumerable<Lesson> lessons, IEnumerable<Grade> grades) : Person(id,name)
{
    private IEnumerable<Lesson> _lessons = lessons;
    private IEnumerable<Grade> _grades = grades;
    private readonly Group _group = group;
    public IReadOnlyCollection<Lesson> AttendedLessons => _lessons.ToImmutableList();
    public IReadOnlyCollection<Grade> RecievedGrades => _grades.ToImmutableList();
    public Group Group => _group;
    public Student(PersonName name, Group group) : this(Guid.NewGuid(),name, group, [], [])
    {

    }
    public void AttendLesson(Lesson lesson)
    {
        _lessons = _lessons.Append(lesson);

    }
    public void GetGrade(Grade grade)
    {
        _grades = _grades.Append(grade);
    }
    
}
