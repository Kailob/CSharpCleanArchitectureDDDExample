namespace Domain.Common.Models;

/// <summary>
/// Abstraction of Entity.
/// </summary>
/// <typeparam name="TId">ValueObject.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
    /// </summary>
    /// <param name="id">ValueObject.</param>
    protected Entity(TId id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets or sets valueObject.
    /// </summary>
    /// <value>TId.</value>
    public TId Id { get; protected set; }

    /// <summary>
    /// Validates if two objects are equal using operator ==.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    public static bool operator ==(Entity<TId> left, Entity<TId> right) => EqualOperator(left, right);

    /// <summary>
    /// Validates if two objects are different using operator !=.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => NotEqualOperator(left, right);

    /// <summary>
    /// Validates if two objects are equal.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <returns>bool.</returns>
    public bool Equals(Entity<TId>? obj)
    {
        return Equals((object?)obj);
    }

    /// <summary>
    /// Value objects are considered equal if their values are the same.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <returns>bool.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    /// <summary>
    /// Gets object hash code.
    /// </summary>
    /// <returns>int.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Validates if two objects are equal.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    protected static bool EqualOperator(Entity<TId> left, Entity<TId> right)
    {
        return !(left is null ^ right is null) && (ReferenceEquals(left, right) || (left is not null && left.Equals(right)));
    }

    /// <summary>
    /// Validates if two objects are different.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    protected static bool NotEqualOperator(Entity<TId> left, Entity<TId> right)
    {
        return !EqualOperator(left, right);
    }

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    protected Entity()
    {

    }
#pragma warning restore CS8618
}
