namespace GradeBookMicroservice.Application.Models.Base;

public abstract class PersonModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}

}
