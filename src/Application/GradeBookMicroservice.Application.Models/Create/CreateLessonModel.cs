namespace GradeBookMicroservice.Application.Models.Create;

public class CreateLessonModel : ICreateModel
{
    public required string Topic {get; init;}
    public required string Description {get; init;}
    public required GroupModel Group {get; init;}
    public required DateTime ClassTime {get; init;}

}