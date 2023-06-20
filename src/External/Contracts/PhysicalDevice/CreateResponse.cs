// <copyright file="CreateResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.PhysicalDevice
{
    /// <summary>
    /// Create Physical Device Response.
    /// </summary>
    /// <param name="Id">Guid.</param>
    /// <param name="Name">Name.</param>
    /// <returns>CreateResponse Instance.</returns>
    public record CreateResponse(
        Guid Id,
        string Name);
}
