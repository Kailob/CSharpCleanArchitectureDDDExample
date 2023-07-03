using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.DeviceAggregate.Enums;
using Domain.DeviceAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// Software installation.
/// </summary>
public sealed class Software : Entity<SoftwareId>
{
    private Software(
        SoftwareId id,
        string log)
         : base(id)
    {
        Log = log;
        ExecutionStatus = Domain.Common.Enums.ExecutionStatus.Stopped;
    }

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private Software()
    {

    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets software installation log.
    /// </summary>
    /// <value>string.</value>
    public string Log { get; private set; }

    /// <summary>
    /// Gets Software execution status.
    /// </summary>
    /// <value>ExecutionStatus.</value>
    public ExecutionStatus ExecutionStatus { get; private set; }

    /// <summary>
    /// Gets Software Created Date Time.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; private set; } = DateTime.Now;

    /// <summary>
    /// Gets Software Updated Date Time.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; private set; } = DateTime.Now;

    /// <summary>
    /// Create New Software instance.
    /// </summary>
    /// <param name="log">Installation Log.</param>
    /// <returns>Software instance.</returns>
    public static Software Create(
        string log)
    {
        return new(
            SoftwareId.CreateUnique(),
            log);
    }

    /// <summary>
    /// Prepares the clean up scripts to unlink the physical device from IoTHub.
    /// </summary>
    /// <param name="linuxOS">Device Linux OS.</param>
    /// <returns>List of strings representing O.S. commands.</returns>
    public static List<string> GetCleanUpScripts(LinuxOS linuxOS)
    {
        var scripts = new List<string>();

        // Remove the Moby engine.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
            case LinuxOS.UbuntuFocalFossa:
            case LinuxOS.UbuntuBionicBeaver:
            case LinuxOS.DebianBullseye:
                scripts.Add("sudo apt remove -y moby-engine");
                break;
            case LinuxOS.RedHat8x:
            case LinuxOS.RedHat9x:
                scripts.Add("sudo yum remove moby-engine moby-cli");
                break;
        }

        // Remove Microsoft package signing key to device list of trusted keys.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
                scripts.Add("sudo apt remove -y aziot-edge");
                break;
            case LinuxOS.UbuntuBionicBeaver:
            case LinuxOS.UbuntuFocalFossa:
            case LinuxOS.DebianBullseye:
                scripts.Add("sudo apt remove -y aziot-edge defender-iot-micro-agent-edge");
                break;
            case LinuxOS.RedHat8x:
            case LinuxOS.RedHat9x:
                scripts.Add("sudo yum remove -y aziot-edge");
                break;
        }

        // Remove Microsoft package signing key to device list of trusted keys.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
            case LinuxOS.UbuntuBionicBeaver:
            case LinuxOS.UbuntuFocalFossa:
            case LinuxOS.DebianBullseye:
                scripts.Add("sudo apt -y autoremove");
                break;
            case LinuxOS.RedHat8x:
            case LinuxOS.RedHat9x:
                scripts.Add("sudo yum -y autoremove");
                break;
        }

        return scripts;
    }

    /// <summary>
    /// Prepares the installation scripts based on.
    /// <![CDATA[ https://learn.microsoft.com/en-us/azure/iot-edge/how-to-provision-single-device-linux-symmetric?view=iotedge-1.4&tabs=azure-portal%2Crhel ]]>
    /// </summary>
    /// <param name="deviceConnectionString">IoT Device Connection String.</param>
    /// <param name="linuxOS">Device Linux OS.</param>
    /// <returns>List of strings representing O.S. commands.</returns>
    public static IReadOnlyList<string> GetInstallScripts(string deviceConnectionString, LinuxOS linuxOS)
    {
        if (string.IsNullOrEmpty(deviceConnectionString))
        {
            throw new ArgumentNullException(nameof(deviceConnectionString));
        }

        var scripts = GetCleanUpScripts(linuxOS);

        // Add Microsoft package signing key to device list of trusted keys.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
                scripts.Add("wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb");
                scripts.Add("sudo dpkg -i packages-microsoft-prod.deb");
                scripts.Add("rm packages-microsoft-prod.deb");
                break;
            case LinuxOS.UbuntuFocalFossa:
                scripts.Add("wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb");
                scripts.Add("sudo dpkg -i packages-microsoft-prod.deb");
                scripts.Add("rm packages-microsoft-prod.deb");
                break;
            case LinuxOS.UbuntuBionicBeaver:
                scripts.Add("wget https://packages.microsoft.com/config/ubuntu/18.04/multiarch/packages-microsoft-prod.deb -O packages-microsoft-prod.deb");
                scripts.Add("sudo dpkg -i packages-microsoft-prod.deb");
                scripts.Add("rm packages-microsoft-prod.deb");
                break;
            case LinuxOS.DebianBullseye:
                scripts.Add("curl https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb > ./packages-microsoft-prod.deb");
                scripts.Add("sudo apt install ./packages-microsoft-prod.deb");
                break;
            case LinuxOS.RedHat8x:
                scripts.Add("wget https://packages.microsoft.com/config/rhel/8/packages-microsoft-prod.rpm -O packages-microsoft-prod.rpm");
                scripts.Add("sudo yum localinstall packages-microsoft-prod.rpm");
                scripts.Add("rm packages-microsoft-prod.rpm");
                break;
            case LinuxOS.RedHat9x:
                scripts.Add("wget https://packages.microsoft.com/config/rhel/9.0/packages-microsoft-prod.rpm -O packages-microsoft-prod.rpm");
                scripts.Add("sudo yum localinstall packages-microsoft-prod.rpm");
                scripts.Add("rm packages-microsoft-prod.rpm");
                break;
        }

        scripts.Add("sudo apt-get update;");

        // Install the Moby engine.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
            case LinuxOS.UbuntuFocalFossa:
            case LinuxOS.UbuntuBionicBeaver:
            case LinuxOS.DebianBullseye:
                scripts.Add("sudo apt-get install -y moby-engine");
                break;
            case LinuxOS.RedHat8x:
            case LinuxOS.RedHat9x:
                scripts.Add("sudo yum install moby-engine moby-cli");
                break;
        }

        // Add Microsoft package signing key to device list of trusted keys.
        switch (linuxOS)
        {
            case LinuxOS.UbuntuJammyJellyfish:
                scripts.Add("sudo apt-get install -y aziot-edge");
                break;
            case LinuxOS.UbuntuBionicBeaver:
            case LinuxOS.UbuntuFocalFossa:
            case LinuxOS.DebianBullseye:
                scripts.Add("sudo apt-get install -y aziot-edge defender-iot-micro-agent-edge");
                break;
            case LinuxOS.RedHat8x:
            case LinuxOS.RedHat9x:
                scripts.Add("sudo yum install aziot-edge");
                break;
        }

        // Provision the device with its cloud identity
        scripts.Add($"sudo iotedge config mp --connection-string '{deviceConnectionString}' --force");

        // Apply the configuration changes
        scripts.Add("sudo iotedge config apply -c '/etc/aziot/config.toml'");

        // To view the configuration file, you can open it:
        scripts.Add("sudo nano /etc/aziot/config.toml");

        return scripts;
    }

    /// <summary>
    /// Prepares the health check scripts based on.
    /// <![CDATA[ https://learn.microsoft.com/en-us/azure/iot-edge/how-to-provision-single-device-linux-symmetric?view=iotedge-1.4&tabs=azure-portal%2Crhel#verify-successful-configuration ]]>
    /// </summary>
    /// <returns>List of strings representing O.S. commands.</returns>
    public static List<string> GetHealtCheckScripts()
    {
        var scripts = new List<string>()
        {
            "sudo iotedge system status",
            "sudo iotedge check --verbose",
        };
        return scripts;
    }
}
