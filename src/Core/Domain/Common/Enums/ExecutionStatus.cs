namespace Domain.Common.Enums
{
    using System.ComponentModel;

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
}
