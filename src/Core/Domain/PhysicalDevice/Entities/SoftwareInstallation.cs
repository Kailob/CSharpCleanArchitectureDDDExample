


using CADDD.Domain.Common.Enums;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class SoftwareInstallation : Entity<SoftwareInstallationId>
{
    public string Log { get; }
    public ExecutionStatus Status { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    private SoftwareInstallation(
        SoftwareInstallationId id,
        string log,
        ExecutionStatus status
    ) : base(id)
    {
        Log = log;
        Status = status;
    }

    public static SoftwareInstallation Create(
        string log,
        ExecutionStatus status
    )
    {
        return new(
            SoftwareInstallationId.CreateUnique(),
            log,
            status
        );
        
    }
}