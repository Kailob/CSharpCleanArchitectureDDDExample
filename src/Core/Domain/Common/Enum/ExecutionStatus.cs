using System.ComponentModel;

namespace CADDD.Domain.Common.Enums;

public enum ExecutionStatus
{
    [Description("Ready")]
    Ready,

    [Description("Running")]
    Running,

    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,
}
