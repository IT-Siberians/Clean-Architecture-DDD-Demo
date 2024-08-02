using GradebookMicroservice.Common.Enumes;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;

namespace GradeBookMicroservice.Domain.Entities;

public class Grade : Entity<Guid>
{
    #region Private fields
    private Teacher _teacher;
    private Student _student;
    private Lesson _lesson;
    private DateTime _gradedTime;
    private string? _comment;
    private Mark _mark;
    #endregion
    #region Public readable properties
    public Teacher Teacher => _teacher;
    public Student Student => _student;
    public Lesson Lesson => _lesson;
    public DateTime GradedTime => _gradedTime;
    public string? Comment => _comment;
    public Mark Mark => _mark;
    #endregion
    #region Constructors
    public Grade(Guid id, Teacher teacher, Student student, Lesson lesson, DateTime gradeTime, Mark mark, string? comment = null) : base(id)
    {
        if (lesson.State != LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if (lesson.Teacher != teacher)
            throw new AnotherTeacherLessonGradedException(lesson, teacher);
        if (gradeTime < lesson.ClassTime)
            throw new LessonNotStartedException(lesson);
        if (!student.AttendedLessons.Contains(lesson))
            throw new LessonNotVisitedException(lesson, student);
        _teacher = teacher;
        _student = student;
        _lesson = lesson;
        _gradedTime = gradeTime;
        _mark = mark;
        _comment = comment;

    }
    public Grade(Teacher teacher, Student student, Lesson lesson, DateTime gradeTime, Mark mark, string? comment = null) : this(Guid.NewGuid(),teacher,student,lesson,gradeTime,mark, comment)
    {
        
    }
    #endregion
}
