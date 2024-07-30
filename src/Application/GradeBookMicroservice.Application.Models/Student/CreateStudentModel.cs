namespace GradeBookMicroservice.Application.Models.Student;

public class CreateStudentModel : PersonCreateModel
{
    public required Guid GroupId { get; init; }

}
