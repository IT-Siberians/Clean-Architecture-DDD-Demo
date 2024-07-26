namespace GradeBookMicroservice.Application.Models.Create;

public class CreateGradeModel : ICreateModel
{
    public required TeacherModel Teacher { get; init; }
    public required LessonModel Lesson { get; init; }
    public required StudentModel Student { get; init; }
    public string? Comment {get; init;}

}
