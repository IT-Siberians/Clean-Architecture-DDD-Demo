namespace GradeBookMicroservice.Application.Models.Base;

public abstract class PersonCreateModel : ICreateModel
{
    public required string Name {get; init;}
}
