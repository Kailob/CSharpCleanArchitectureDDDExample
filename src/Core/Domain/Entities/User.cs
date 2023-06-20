namespace Domain.Entities;

/// <summary>
/// User Entity.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    /// <returns>Guid.</returns>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets First Name.
    /// </summary>
    /// <value>string.</value>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets Last Name.
    /// </summary>
    /// <value>string.</value>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets Email.
    /// </summary>
    /// <value>string.</value>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets Password.
    /// </summary>
    /// <value>string.</value>
    public string Password { get; set; } = null!;
}
