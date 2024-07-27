namespace GradeBookMicroservice.WebHost.Requests.Lesson;

public class CreateLessonRequest
{
    public required Guid TeacherId {get; init;}
    public required Guid GroupId {get; init;}
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required DateTime ClassTime {get; init;}
}
