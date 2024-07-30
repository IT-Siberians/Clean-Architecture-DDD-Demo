using GradeBookMicroservice.Application.Models.Base;

namespace GradeBookMicroservice.Application.Models;

public abstract class PersonModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}

}
