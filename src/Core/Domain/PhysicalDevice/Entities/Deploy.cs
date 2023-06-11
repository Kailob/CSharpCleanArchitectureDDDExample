using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class Deploy : Entity<DeployId>
{
    private Deploy(
        DeployId id,
        string manifest)
        : base(id)
    {
        Manifest = manifest;
    }

    public string Manifest { get; }

    public DateTime CreatedDateTime { get; } = DateTime.Now;

    public static Deploy Create(
        string manifest)
    {
        return new(
            DeployId.CreateUnique(),
            manifest);
    }
}