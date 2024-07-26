namespace GradeBookMicroservice.WebHost;

public class GroupShortResponse
{
    public Guid Id {get; init;}
    public required string Name {get; init;}
    public required string Description {get; init;}

}
