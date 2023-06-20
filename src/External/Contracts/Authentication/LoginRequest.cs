// <copyright file="LoginRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.Authentication
{
    /// <summary>
    /// Login Request.
    /// </summary>
    /// <param name="Email">Email.</param>
    /// <param name="Password">Password.</param>
    /// <returns>LoginRequest instance.</returns>
    public record LoginRequest(
        string Email,
        string Password);
}
