using GradeBookMicroservice.Domain.Entities.Base;

namespace GradeBookMicroservice.Domain.Entities;

public class Grade(Teacher teacher, Student student, Lesson lesson, string? comment=null) : Entity<Guid>
{
    private readonly Teacher _teacher = teacher;
    private readonly Student _student = student;
    private readonly Lesson _lesson = lesson;
    private readonly DateTime _gradedTime = DateTime.Now;
    private readonly string? _comment = comment;
    public Teacher Teacher => _teacher;
    public Student Student => _student;
    public Lesson Lesson => _lesson;
    public DateTime GradedTime => _gradedTime;
    public string? Comment => _comment;



}
