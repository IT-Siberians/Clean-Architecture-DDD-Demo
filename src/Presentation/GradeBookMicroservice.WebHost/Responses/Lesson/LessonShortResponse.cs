namespace GradeBookMicroservice.WebHost.Responses.Lesson;

public class LessonShortResponse
{
    public Guid Id { get; init; }
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required DateTime ClassTime {get; init;}

}
