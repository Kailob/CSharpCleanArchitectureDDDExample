// <copyright file="MetaDataId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class MetaDataId : ValueObject
{
    private MetaDataId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MetaDataId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}