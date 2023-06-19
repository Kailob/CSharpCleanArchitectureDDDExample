using Domain.Admin.ValueObjects;
using Domain.Common.Models;

namespace Domain.Admin;

/// <summary>
/// Admin aggregate.
/// </summary>
public sealed class Admin : AggregateRoot<AdminId>
{
    private Admin(
        AdminId id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; }

    /// <summary>
    /// Gets description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; }

    /// <summary>
    /// Gets create date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets updated date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="Admin"/> aggregate.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">description.</param>
    /// <returns>Admin instance.</returns>
    public static Admin Create(
        string name,
        string description)
    {
        return new(
            AdminId.CreateUnique(),
            name,
            description);
    }
}
