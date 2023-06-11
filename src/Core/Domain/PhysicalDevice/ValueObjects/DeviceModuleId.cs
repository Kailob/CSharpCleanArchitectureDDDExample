// <copyright file="DeviceModuleId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class DeviceModuleId : ValueObject
{
    private DeviceModuleId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DeviceModuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}