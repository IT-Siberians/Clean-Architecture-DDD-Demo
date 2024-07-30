using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Teacher(Guid id, PersonName name, IEnumerable<Lesson> lessons, IEnumerable<Grade> grades) : Person(id,name)
{
    private IEnumerable<Lesson> _lessons = lessons;
    private IEnumerable<Grade> _grades = grades;
    public IReadOnlyCollection<Lesson> TeachedLessons => _lessons.Where(lesson => lesson.State==LessonStatus.Teached).ToImmutableList();
    public IReadOnlyCollection<Lesson> SchedulledLessons => _lessons.Where(lesson => lesson.State==LessonStatus.New).ToImmutableList();
    public IReadOnlyCollection<Grade> AssignedGrades => _grades.ToImmutableList();

    public Teacher(PersonName name) : this(Guid.NewGuid(),name, [], [])
    {

    }
    
    public void TeachLesson(Lesson lesson)
    {
        if(lesson.State == LessonStatus.Teached)
            throw new LessonAlreadyTeachedException(lesson);
        lesson.Teach();
        if(TeachedLessons.Contains(lesson))
            throw new DoubleTeachedLessonException(lesson, this);
        if(_lessons.Contains(lesson))
            _lessons = _lessons.Append(lesson);
    }
    public void GradeStudent(Student student, Mark mark, Lesson lesson, string? comment=null)
    {
        if(lesson.State!=LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if(!_lessons.Contains(lesson))
            throw new AnotherTeacherLessonGradedException(lesson, this);
        if(_grades.FirstOrDefault(gr => gr.Student == student && gr.Lesson == lesson)!=null)
            throw new DoubleGradeStudentLesson(lesson, student);
        var grade = new Grade(this, student, lesson,DateTime.Now,mark, comment);
        student.GetGrade(grade);
        _grades = _grades.Append(grade);
    }
    internal void ScheduleLesson(Lesson lesson)
    {
        if(lesson.State!=LessonStatus.New)
            throw new LessonAlreadyTeachedException(lesson);
        if(!_lessons.Contains(lesson))
            _lessons = _lessons.Append(lesson);

    }

}
