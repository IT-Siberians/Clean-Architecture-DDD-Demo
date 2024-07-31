namespace GradeBookMicroservice.Application.Models.Student;

public class VisitLessonModel
{
    public required Guid StudentId { get; init; }
    public required Guid LessonId { get; init; }

}
