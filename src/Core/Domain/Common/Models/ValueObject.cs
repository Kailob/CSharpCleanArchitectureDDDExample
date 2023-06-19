namespace Domain.Common.Models;

/// <summary>
/// Abstraction of ValueObject.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Validates if two objects are equal using operator ==.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    public static bool operator ==(ValueObject left, ValueObject right) => EqualOperator(left, right);

    /// <summary>
    /// Validates if two objects are different using operator !=.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    public static bool operator !=(ValueObject left, ValueObject right) => NotEqualOperator(left, right);

    /// <summary>
    /// Validates if two objects are equal.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <returns>bool.</returns>
    public bool Equals(ValueObject? obj)
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
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    /// <summary>
    /// Gets object hash code.
    /// </summary>
    /// <returns>int.</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0) // If x is not null, get HashCode OR return 0
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Validates if two objects are equal.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        return !(left is null ^ right is null) && (ReferenceEquals(left, right) || (left is not null && left.Equals(right)));
    }

    /// <summary>
    /// Validates if two objects are different.
    /// </summary>
    /// <param name="left">Left Object.</param>
    /// <param name="right">Right Object.</param>
    /// <returns>bool.</returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    /// <summary>
    /// Abstract to return object equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();
}
