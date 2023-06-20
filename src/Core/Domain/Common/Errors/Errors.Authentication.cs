using ErrorOr;

namespace Domain.Common.Errors;

/// <summary>
/// Partial Errors class.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// Authentication Errors.
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Gets Invalid Credentials error.
        /// </summary>
        /// <returns>Error.</returns>
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");
    }
}
