using GradeBookMicroservice.Application.Models.Base;

namespace GradeBookMicroservice.Application.Models.Group;

public class CreateGroupModel : ICreateModel
{
    public required string Name {get; init;}
    public required string Description {get; init;}

}
