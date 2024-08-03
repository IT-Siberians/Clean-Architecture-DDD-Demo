using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities.Base;

public class Person(Guid id, PersonName name) : Entity<Guid>(id)
{
    public PersonName Name => name;
}
