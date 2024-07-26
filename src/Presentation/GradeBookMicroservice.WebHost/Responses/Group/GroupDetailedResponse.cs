using GradeBookMicroservice.WebHost.Responses.Student;

namespace GradeBookMicroservice.WebHost.Responses.Group;

public class GroupDetailedResponse
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}
    public IEnumerable<StudentShortResponse> Students {get; init;} = [];

}
