namespace GradeBookMicroservice.WebHost.Requests.Student;

public class CreateStudentRequest
{
    public required string Name {get; init;}
    public required Guid GroupId{get; init;}

}
