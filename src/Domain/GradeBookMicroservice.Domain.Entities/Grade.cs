using GradebookMicroservice.Common.Enumes;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;

namespace GradeBookMicroservice.Domain.Entities;

public class Grade : Entity<Guid>
{
    #region Public readable properties
    public Teacher Teacher  {get;}
    public Student Student {get;}
    public Lesson Lesson  {get;}
    public DateTime GradedTime {get; }
    public string? Comment {get; }
    public Mark Mark {get; }
    #endregion
    #region Constructors
    protected Grade(Guid id, Teacher teacher, Student student, Lesson lesson, DateTime gradeTime, Mark mark, string? comment = null) : base(id)
    {
        if (lesson.State != LessonStatus.Teached)
            throw new LessonNotStartedException(lesson);
        if (lesson.Teacher != teacher)
            throw new AnotherTeacherLessonGradedException(lesson, teacher);
        if (gradeTime.ToUniversalTime() < lesson.ClassTime.ToUniversalTime())
            throw new LessonNotStartedException(lesson);
        if (!student.AttendedLessons.Contains(lesson))
            throw new LessonNotVisitedException(lesson, student);
        Teacher= teacher;
        Student = student;
        Lesson = lesson;
        GradedTime = gradeTime;
        Mark = mark;
        Comment = comment;

    }
    public Grade(Teacher teacher, Student student, Lesson lesson, DateTime gradeTime, Mark mark, string? comment = null) : this(Guid.NewGuid(),teacher,student,lesson,gradeTime,mark, comment)
    {
        
    }
    protected Grade() : base(Guid.NewGuid())
    {
        
    }
    #endregion
}
