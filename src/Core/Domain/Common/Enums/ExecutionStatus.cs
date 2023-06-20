namespace Domain.Common.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Execution Status.
    /// </summary>
    public enum ExecutionStatus
    {
        /// <summary>
        /// Stopped.
        /// </summary>
        [Description("Stopped")]
        Stopped,

        /// <summary>
        /// Ready.
        /// </summary>
        [Description("Ready")]
        Ready,

        /// <summary>
        /// Running.
        /// </summary>
        [Description("Running")]
        Running,

        /// <summary>
        /// Completed.
        /// </summary>
        [Description("Completed")]
        Completed,

        /// <summary>
        /// Failed.
        /// </summary>
        [Description("Failed")]
        Failed,
    }
}
