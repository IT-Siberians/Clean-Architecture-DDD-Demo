using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Teacher(Guid id, PersonName name, IEnumerable<Lesson> lessons, IEnumerable<Grade> grades) : Person(id,name)
{
    private IEnumerable<Lesson> _lessons = lessons;
    private IEnumerable<Grade> _grades = grades;
    public IReadOnlyCollection<Lesson> TeachedLessons => _lessons.ToImmutableList();
    public IReadOnlyCollection<Grade> AssignedGrades => _grades.ToImmutableList();

    public Teacher(PersonName name) : this(Guid.NewGuid(),name, [], [])
    {

    }
    public void TeachLesson(Lesson lesson)
    {
        _lessons = _lessons.Append(lesson);
    }
    public void GradeStudent(Student student, int mark, Lesson lesson, string? comment=null)
    {
        var grade = new Grade(this, student, lesson, comment);
        _grades = _grades.Append(grade);
        student.GetGrade(grade);

    }

}
