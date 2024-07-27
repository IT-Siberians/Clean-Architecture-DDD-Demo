using GradeBookMicroservice.Application.Models.Lesson;
using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Application.Models.Teacher;

namespace GradeBookMicroservice.Application.Models.Grade;

public class CreateGradeModel : ICreateModel
{
    public required TeacherModel Teacher { get; init; }
    public required LessonModel Lesson { get; init; }
    public required StudentModel Student { get; init; }
    public string? Comment {get; init;}

}
