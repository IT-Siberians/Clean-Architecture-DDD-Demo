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
        lesson.Teach();
        if(_lessons.Contains(lesson))
            throw new InvalidOperationException("Can not teach already teached lesson");
        _lessons = _lessons.Append(lesson);
    }
    public void GradeStudent(Student student, Mark mark, Lesson lesson, string? comment=null)
    {
        if(!_lessons.Contains(lesson))
            throw new InvalidOperationException("Can not grade not teached lesson");
        if(_grades.FirstOrDefault(gr => gr.Student == student && gr.Lesson == lesson)!=null)
            throw new InvalidOperationException("Can not grade already graded lesson");
        var grade = new Grade(this, student, lesson,mark, comment);
        student.GetGrade(grade);
        _grades = _grades.Append(grade);
    }

}
