using GradeBookMicroservice.Application.Models.Base;

namespace GradeBookMicroservice.Application.Models.Student;

public class CreateStudentModel : PersonCreateModel
{
    public required Guid GroupId { get; init; }

}
