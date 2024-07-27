namespace GradeBookMicroservice.WebHost.Requests.Group;

public class EnrollStudentRequest
{
    public required Guid StudentId {get; init;}
    public required Guid GroupId {get; init;}

}
