namespace GradeBookMicroservice.Application.Models.Create;

public class CreateStudentModel : PersonCreateModel
{
    public required Guid GroupId {get; init;}

}
