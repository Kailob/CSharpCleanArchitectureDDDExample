namespace Domain.Common.Models;

/// <summary>
/// Abstraction of AggregateRoot.
/// </summary>
/// <typeparam name="TId">ValueObject.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="id">Entity.</param>
    public AggregateRoot(TId id)
    : base(id)
    {
    }
}
