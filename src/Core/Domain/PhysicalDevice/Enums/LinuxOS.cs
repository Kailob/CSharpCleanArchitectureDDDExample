using System.ComponentModel;

namespace Domain.PhysicalDevice.Enums;

/// <summary>
/// Linux Operative Systems enum.
/// </summary>
public enum LinuxOS
{
    /// <summary>
    /// Debian 11.
    /// </summary>
    [Description("Debian 11")]
    DebianBullseye,

    /// <summary>
    /// Red Hat 8.x (amd64).
    /// </summary>
    [Description("Red Hat 8.x (amd64)")]
    RedHat8x,

    /// <summary>
    /// Red Hat 9.x (amd64).
    /// </summary>
    [Description("Red Hat 9.x (amd64)")]
    RedHat9x,

    /// <summary>
    /// Ubuntu 22.04.
    /// </summary>
    [Description("Ubuntu 22.04")]
    UbuntuJammyJellyfish,

    /// <summary>
    /// Ubuntu 20.04.
    /// </summary>
    [Description("Ubuntu 20.04")]
    UbuntuFocalFossa,

    /// <summary>
    /// Ubuntu 18.04.
    /// </summary>
    [Description("Ubuntu 18.04")]
    UbuntuBionicBeaver,
}
