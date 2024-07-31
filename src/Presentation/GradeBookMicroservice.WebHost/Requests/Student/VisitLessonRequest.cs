namespace GradeBookMicroservice.WebHost.Requests.Student;

public class VisitLessonRequest
{
    public required Guid LessonId {get; init;}
    public required Guid StudentId {get; init;}

}
