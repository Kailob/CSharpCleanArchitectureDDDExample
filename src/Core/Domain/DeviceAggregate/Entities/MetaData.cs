using Domain.Common.Models;
using Domain.DeviceAggregate.Enums;
using Domain.DeviceAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// Meta Data Entity.
/// </summary>
public sealed class MetaData
{
    private MetaData(
        string macAddress,
        string ipAddress,
        string username,
        string password,
        LinuxOS linuxOS)
    {
        MacAddress = macAddress;
        IpAddress = ipAddress;
        Username = username;
        Password = password;
        LinuxOS = linuxOS;
    }

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private MetaData()
    {

    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets MacAddress.
    /// </summary>
    /// <value>string.</value>
    public string MacAddress { get; private set; }

    /// <summary>
    /// Gets IpAddress.
    /// </summary>
    /// <value>string.</value>
    public string IpAddress { get; private set; }

    /// <summary>
    /// Gets Username.
    /// </summary>
    /// <value>string.</value>
    public string Username { get; private set; }

    /// <summary>
    /// Gets Password.
    /// </summary>
    /// <value>string.</value>
    public string Password { get; private set; }

    /// <summary>
    /// Gets Linux Operative System.
    /// </summary>
    /// <value>LinuxOS.</value>
    public LinuxOS LinuxOS { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetaData"/> entity.
    /// </summary>
    /// <param name="macAddress">MacAddress.</param>
    /// <param name="ipAddress">IpAddress.</param>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <param name="linuxOS">LinuxOs.</param>
    /// <returns>MetaData.</returns>
    public static MetaData Create(
        string macAddress,
        string ipAddress,
        string username,
        string password,
        LinuxOS linuxOS)
    {
        return new(
            macAddress,
            ipAddress,
            username,
            password,
            linuxOS);
    }
}
