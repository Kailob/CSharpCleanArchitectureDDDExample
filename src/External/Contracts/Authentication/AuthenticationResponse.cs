// <copyright file="AuthenticationResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.Authentication
{
    /// <summary>
    /// Authentication Response.
    /// </summary>
    /// <param name="Id">User's Id.</param>
    /// <param name="FirstName">User's first name.</param>
    /// <param name="LastName">User's last name.</param>
    /// <param name="Email">Email.</param>
    /// <param name="Token">JWToken.</param>
    /// <returns>AuthenticationResponse instance.</returns>
    public record AuthenticationResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
