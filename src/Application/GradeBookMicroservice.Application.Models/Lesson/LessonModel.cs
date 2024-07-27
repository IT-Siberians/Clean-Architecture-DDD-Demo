namespace GradeBookMicroservice.Application.Models.Lesson;

public class LessonModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required TeacherModel Teacher {get; init;}
    public required GroupModel Group {get; init;}
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required DateTime ClassTime {get; init;}
}
