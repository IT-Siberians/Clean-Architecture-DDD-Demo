﻿namespace GradeBookMicroservice.Domain.Entities.Base;
/// <summary>
/// Represents an entity in the system.
/// </summary>
/// <typeparam name="TId">The type of the entity's ID.</typeparam>
/// <param name="id">The ID of the entity.</param>
/// <remarks>
/// Initializes a new instance of the <see cref="Entity{TId}"/> class.
/// </remarks>
/// <param name="id">The ID of the entity.</param>
public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>  where TId : struct
{

    /// <summary>
    /// Gets the ID of the entity.
    /// </summary>
    public TId Id {get; protected set;} = id;

    public override bool Equals(object? obj) =>  obj is Entity<TId> other && EqualityComparer<TId>.Default.Equals(Id, other.Id);
    
    public override int GetHashCode() => EqualityComparer<TId>.Default.GetHashCode(Id);

    public bool Equals(Entity<TId>? other) => other is not null && EqualityComparer<TId>.Default.Equals(Id, other.Id);
    public override string ToString() => Id.ToString() ?? "";
    public static bool operator==(Entity<TId> first, Entity<TId> second)
    {
        if(ReferenceEquals(first, second))
            return true;
        return !first.Id.Equals(default(TId)) && first.Equals(second);
    }
    public static bool operator!=(Entity<TId> first, Entity<TId> second) =>!(first == second);
}