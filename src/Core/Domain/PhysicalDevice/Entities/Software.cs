


using CADDD.Domain.Common.Enums;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.Enums;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class Software : Entity<SoftwareId>
{
    public string Log { get; }
    public ExecutionStatus Status { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    private Software(
        SoftwareId id,
        string log,
        ExecutionStatus status
    ) : base(id)
    {
        Log = log;
        Status = status;
    }

    public static Software Create(
        string log,
        ExecutionStatus status
    )
    {
        return new(
            SoftwareId.CreateUnique(),
            log,
            status
        );
    }

    /// <summary>
    /// Prepares the clean up scripts
    /// to unlink the physical device from IoTHub
    /// </summary>
    /// <param name="LinuxOS">Device Linux OS</param>
    /// <returns>List<string></returns>
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


        //  Remove Microsoft package signing key to device list of trusted keys.
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

        //  Remove Microsoft package signing key to device list of trusted keys.
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
    /// Prepares the instalations scripts based on 
    /// https://learn.microsoft.com/en-us/azure/iot-edge/how-to-provision-single-device-linux-symmetric?view=iotedge-1.4&tabs=azure-portal%2Crhel
    /// </summary>
    /// <returns>List<string></returns>
    public static IReadOnlyList<string> GetInstallScripts(string DeviceConnectionString, LinuxOS linuxOS)
    {
        if (string.IsNullOrEmpty(DeviceConnectionString)) throw new ArgumentNullException(nameof(DeviceConnectionString));

        var scripts = GetCleanUpScripts(linuxOS);

        //  Add Microsoft package signing key to device list of trusted keys.
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


        //  Add Microsoft package signing key to device list of trusted keys.
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

        //  Provision the device with its cloud identity
        scripts.Add($"sudo iotedge config mp --connection-string '{DeviceConnectionString}' --force");

        //  Apply the configuration changes
        scripts.Add("sudo iotedge config apply -c '/etc/aziot/config.toml'");

        //  To view the configuration file, you can open it:
        scripts.Add("sudo nano /etc/aziot/config.toml");

        return scripts;
    }
    /// <summary>
    /// Prepares the health check scripts based on 
    /// https://learn.microsoft.com/en-us/azure/iot-edge/how-to-provision-single-device-linux-symmetric?view=iotedge-1.4&tabs=azure-portal%2Crhel#verify-successful-configuration
    /// </summary>
    /// <returns>List<string></returns>
    public static List<string> GetHealtCheckScripts()
    {
        var scripts = new List<string>() {
            "sudo iotedge system status",
            //"sudo iotedge system logs",
            "sudo iotedge check --verbose"
        };
        return scripts;
    }
}