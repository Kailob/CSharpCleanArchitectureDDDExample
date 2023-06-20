// <copyright file="RegisterRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.Authentication
{
    /// <summary>
    /// Register Request.
    /// </summary>
    /// <param name="FirstName">First Name.</param>
    /// <param name="LastName">Last Name.</param>
    /// <param name="Email">Email.</param>
    /// <param name="Password">Password.</param>
    /// <returns>RegisterRequest instance.</returns>
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
