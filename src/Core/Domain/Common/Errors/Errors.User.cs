using ErrorOr;

namespace Domain.Common.Errors;

/// <summary>
/// Partial Errors class.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// User Errors.
    /// </summary>
    public static class User
    {
        /// <summary>
        /// Gets Duplicate Email Error.
        /// </summary>
        /// <returns>Error.</returns>
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", "Email already exits.");
    }
}
