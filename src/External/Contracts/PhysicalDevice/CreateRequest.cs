// <copyright file="CreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.PhysicalDevice
{
    /// <summary>
    /// Physical Device Create Request Object.
    /// </summary>
    /// <param name="Name">Name.</param>
    /// <param name="Description">Description.</param>
    /// <returns>CreateRequest Instance.</returns>
    public record CreateRequest(
        string Name,
        string Description);
}
