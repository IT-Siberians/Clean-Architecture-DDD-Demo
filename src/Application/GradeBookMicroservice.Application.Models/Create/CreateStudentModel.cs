namespace GradeBookMicroservice.Application.Models.Create;

public class CreateStudentModel : PersonCreateModel
{
    public required GroupModel Group {get; init;}

}
