namespace GradeBookMicroservice.Application.Models.Group;

public class EnrollStudentModel
{
    public required Guid StudentId {get; init;}
    public required Guid GroupId {get; init;}

}
