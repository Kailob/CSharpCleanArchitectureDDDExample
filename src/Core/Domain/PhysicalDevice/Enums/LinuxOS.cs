using System.ComponentModel;

namespace CADDD.Domain.PhysicalDevice.Enums;

public enum LinuxOS
{
    [Description("Debian 11")]
    DebianBullseye,

    [Description("Red Hat 8.x (amd64)")]
    RedHat8x,

    [Description("Red Hat 9.x (amd64)")]
    RedHat9x,

    [Description("Ubuntu 22.04")]
    UbuntuJammyJellyfish,

    [Description("Ubuntu 20.04")]
    UbuntuFocalFossa,

    [Description("Ubuntu 18.04")]
    UbuntuBionicBeaver,
}
