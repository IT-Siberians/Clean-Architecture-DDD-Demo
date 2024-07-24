using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities.Base;

public class Person(Guid id, PersonName name) : Entity<Guid>(id)
{
    private readonly PersonName _name = name;
    public PersonName Name => _name;
}
