
namespace CADDD.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    protected static bool EqualOperator(Entity<TId> left, Entity<TId> right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(Entity<TId> left, Entity<TId> right)
    {
        return !EqualOperator(left, right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> one, Entity<TId> two) => EqualOperator(one, two);

    public static bool operator !=(Entity<TId> one, Entity<TId> two) => NotEqualOperator(one, two);

    public bool Equals(Entity<TId>? other)
    {
        return Equals( (object?)other );
    }

}