using GradebookMicroservice.Common.Enumes;

namespace GradeBookMicroservice.Application.Models.Teacher;

public class GradeStudentModel
{
    public required Guid StudentId { get; init; }
    public required Guid TeacherId { get; init; }
    public required Guid LessonId { get; init; }
    public required Mark Mark { get; init; }
    public string? Comment {get; init;}
    

}
