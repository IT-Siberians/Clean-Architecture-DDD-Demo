namespace GradeBookMicroservice.WebHost.Requests.Teacher;

public class TeachLessonRequest
{
    public required Guid TeacherId {get; init;}
    public required Guid LessonId {get; init;}

}
