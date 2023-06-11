// <copyright file="CreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CADDD.Contracts.PhysicalDevice;

public record CreateRequest(
    string Name,
    string Description);