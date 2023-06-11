// <copyright file="CreateResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CADDD.Contracts.PhysicalDevice;

public record CreateResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);