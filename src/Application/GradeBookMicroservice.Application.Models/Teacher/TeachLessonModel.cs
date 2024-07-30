namespace GradeBookMicroservice.Application.Models.Teacher;

public class TeachLessonModel
{
    public required Guid TeacherId {get; init;}
    public required Guid LessonId {get; init;}

}
