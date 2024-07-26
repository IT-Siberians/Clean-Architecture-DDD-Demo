using GradeBookMicroservice.WebHost.Responses.Group;

namespace GradeBookMicroservice.WebHost.Responses.Student;

public class StudentDetailedResponse
{
    public Guid Id {get; init;}
    public required string Name {get; init;}
    public required GroupShortResponse Group {get; init;}

}
