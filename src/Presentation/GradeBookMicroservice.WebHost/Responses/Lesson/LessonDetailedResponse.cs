using GradeBookMicroservice.WebHost.Responses.Group;
using GradeBookMicroservice.WebHost.Responses.Teacher;

namespace GradeBookMicroservice.WebHost.Responses.Lesson;

public class LessonDetailedResponse
{
    public Guid Id {get; init;}
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required DateTime ClassTime {get; init;}
    public required TeacherShortResponse Teacher {get; init;}
    public required GroupShortResponse Group {get; init;} 

}
