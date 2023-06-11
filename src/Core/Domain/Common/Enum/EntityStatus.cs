using System.ComponentModel;

namespace CADDD.Domain.Common.Enums;

public enum EntityStatus
{
    [Description("Inactive")]
    Inactive,

    [Description("Active")]
    Active,

    [Description("Deleted")]
    Deleted,
}