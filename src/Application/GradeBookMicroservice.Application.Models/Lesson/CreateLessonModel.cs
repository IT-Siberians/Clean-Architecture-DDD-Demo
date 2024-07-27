namespace GradeBookMicroservice.Application.Models.Lesson;

public class CreateLessonModel : ICreateModel
{
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required Guid GroupId {get; init;}
    public required DateTime ClassTime {get; init;}
    public required Guid TeacherId {get; init;}

}