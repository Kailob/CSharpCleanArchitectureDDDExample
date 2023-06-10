
namespace CADDD.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    // Value objects are considered equal if their values are the same;
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()){
            return false;
        }

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select( x => x?.GetHashCode() ?? 0) // If x is not null, get HashCode OR return 0
            .Aggregate((x, y) => x ^ y );
    }

    public static bool operator ==(ValueObject one, ValueObject two) => EqualOperator(one, two);

    public static bool operator !=(ValueObject one, ValueObject two) => NotEqualOperator(one, two);

    public bool Equals(ValueObject? other)
    {
        return Equals( (object?)other );
    }
}