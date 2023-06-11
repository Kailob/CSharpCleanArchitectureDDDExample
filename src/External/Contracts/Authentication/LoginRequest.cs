// <copyright file="LoginRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CADDD.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password);