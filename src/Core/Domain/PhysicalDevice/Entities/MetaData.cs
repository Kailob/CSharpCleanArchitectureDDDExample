using Domain.Common.Models;
using Domain.PhysicalDevice.Enums;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.PhysicalDevice.Entities;

/// <summary>
/// Meta Data Entity.
/// </summary>
public sealed class MetaData : Entity<MetaDataId>
{
    private MetaData(
        MetaDataId id,
        string macAddress,
        string ipAddress,
        string username,
        string password,
        LinuxOS linuxOS)
        : base(id)
    {
        MacAddress = macAddress;
        IpAddress = ipAddress;
        Username = username;
        Password = password;
        LinuxOS = linuxOS;
    }

    /// <summary>
    /// Gets MacAddress.
    /// </summary>
    /// <value>string.</value>
    public string MacAddress { get; }

    /// <summary>
    /// Gets IpAddress.
    /// </summary>
    /// <value>string.</value>
    public string IpAddress { get; }

    /// <summary>
    /// Gets Username.
    /// </summary>
    /// <value>string.</value>
    public string Username { get; }

    /// <summary>
    /// Gets Password.
    /// </summary>
    /// <value>string.</value>
    public string Password { get; }

    /// <summary>
    /// Gets Linux Operative System.
    /// </summary>
    /// <value>LinuxOS.</value>
    public LinuxOS LinuxOS { get; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets updated date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

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
            MetaDataId.CreateUnique(),
            macAddress,
            ipAddress,
            username,
            password,
            linuxOS);
    }
}
