namespace GradeBookMicroservice.Domain.Entities.Base;

public abstract class Entity<T>(T id)
{
    public T Id { get; } = id;

}
