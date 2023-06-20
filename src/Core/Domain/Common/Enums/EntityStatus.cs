using System.ComponentModel;

namespace Domain.Common.Enums;

/// <summary>
/// Entity Status.
/// </summary>
public enum EntityStatus
{
    /// <summary>
    /// Inactive.
    /// </summary>
    [Description("Inactive")]
    Inactive,

    /// <summary>
    /// Active.
    /// </summary>
    [Description("Active")]
    Active,

    /// <summary>
    /// Deleted.
    /// </summary>
    [Description("Deleted")]
    Deleted,
}
