using GradeBookMicroservice.Domain.Entities.Base;

namespace GradeBookMicroservice.Domain.Entities;

public class Grade(Teacher teacher, Student student, Lesson lesson, Mark mark, string? comment=null) : Entity<Guid>
{
    private  Teacher _teacher = teacher;
    private Student _student = student;
    private Lesson _lesson = lesson;
    private DateTime _gradedTime = DateTime.Now;
    private string? _comment = comment;
    private Mark _mark = mark;
    public Teacher Teacher => _teacher;
    public Student Student => _student;
    public Lesson Lesson => _lesson;
    public DateTime GradedTime => _gradedTime;
    public string? Comment => _comment;
    public Mark Mark => _mark;



}
