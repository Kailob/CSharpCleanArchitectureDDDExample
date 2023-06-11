namespace CADDD.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; protected set; }

    public static bool operator ==(Entity<TId> one, Entity<TId> two) => EqualOperator(one, two);

    public static bool operator !=(Entity<TId> one, Entity<TId> two) => NotEqualOperator(one, two);

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    protected static bool EqualOperator(Entity<TId> left, Entity<TId> right)
    {
        return !(left is null ^ right is null) && (ReferenceEquals(left, right) || (left is not null && left.Equals(right)));
    }

    protected static bool NotEqualOperator(Entity<TId> left, Entity<TId> right)
    {
        return !EqualOperator(left, right);
    }
}