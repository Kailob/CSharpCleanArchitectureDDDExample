// <copyright file="PhysicalDeviceId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class PhysicalDeviceId : ValueObject
{
    private PhysicalDeviceId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static PhysicalDeviceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}