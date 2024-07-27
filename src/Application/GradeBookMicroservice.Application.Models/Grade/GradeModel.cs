using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Application.Models.Teacher;

namespace GradeBookMicroservice.Application.Models.Grade;

public class GradeModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required TeacherModel Teacher {get; init;}
    public required StudentModel Student {get; init;}
    public string? Comment {get; init;}
    public required int Mark {get; init;}
}
