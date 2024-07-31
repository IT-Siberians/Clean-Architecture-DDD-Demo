namespace GradeBookMicroservice.WebHost.Requests.Teacher;

public class GradeStudentModelRequest
{
    public required Guid StudentId {get; init;}
    public required Guid TeacherId {get; init;}
    public required Guid LessonId {get; init;}
    public string? Comment {get; init;}

}
