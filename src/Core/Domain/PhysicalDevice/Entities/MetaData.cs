


using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.Enums;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class MetaData : Entity<MetaDataId>
{
    public string MacAddress { get; }
    public string Ip { get; }
    public string Username { get; }
    public string Password { get; }
    public LinuxOS LinuxOS { get; }

    private MetaData(
        MetaDataId id, 
        string macAddress,
        string ip,
        string username,
        string password,
        LinuxOS linuxOS
    ) : base(id)
    {
        MacAddress = macAddress;
        Ip = ip;
        Username = username;
        Password = password;
        LinuxOS = linuxOS;
    }

    public static MetaData Create(
        string macAddress,
        string ip,
        string username,
        string password,
        LinuxOS linuxOS
    )
    {
        return new(
            MetaDataId.CreateUnique(),
            macAddress,
            ip,
            username,
            password,
            linuxOS
        );
        
    }
}