namespace GradeBookMicroservice.Application.Models;

public class GroupModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}
    public required string Description {get; init;}
    public IEnumerable<StudentModel> Students{get; init;} = [];
}
