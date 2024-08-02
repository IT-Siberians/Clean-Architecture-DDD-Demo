using GradeBookMicroservice.WebHost.Responses.Grade;

namespace GradeBookMicroservice.WebHost.Responses.Teacher;

public class TeacherDetailedResponse
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}
    public required IEnumerable<LessonShortResponse> TeachedLessons {get; init;}
    public required IEnumerable<LessonShortResponse> SchedulledLessons {get; init;}
    public required IEnumerable<GradeResponse> AssignedGrades {get; init;}

}
