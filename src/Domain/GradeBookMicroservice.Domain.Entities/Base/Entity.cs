namespace GradeBookMicroservice.Domain.Entities;

public abstract class Entity<T>(T id)
{
    public T Id {get; } = id;

}
