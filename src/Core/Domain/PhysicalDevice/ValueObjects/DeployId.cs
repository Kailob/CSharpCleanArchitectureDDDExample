// <copyright file="DeployId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class DeployId : ValueObject
{
    private DeployId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; }

    public static DeployId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}