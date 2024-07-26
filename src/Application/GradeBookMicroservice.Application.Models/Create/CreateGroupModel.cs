namespace GradeBookMicroservice.Application.Models.Create;

public class CreateGroupModel : ICreateModel
{
    public required string Name {get; init;}
    public required string Description {get; init;}

}
