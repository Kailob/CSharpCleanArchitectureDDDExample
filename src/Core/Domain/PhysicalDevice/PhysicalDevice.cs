using CADDD.Domain.Common.Enums;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.Entities;
using CADDD.Domain.PhysicalDevice.ValueObjects;
using CADDD.Domain.Tenant.ValueObjects;

namespace CADDD.Domain.PhysicalDevice;

public sealed class PhysicalDevice : AggregateRoot<PhysicalDeviceId>
{
    private readonly List<DeviceModule> _deviceModules = new();
    private readonly List<Camera> _cameras = new();
    private readonly List<Deploy> _deploys = new();
    public string Name { get; }
    public string Description { get; }
    public EntityStatus Status { get; }
    public TenantId TenantId { get; }
    public MetaData MetaData { get; }
    public IoTHubDevice IoTHubDevice { get; }
    public SoftwareInstallation SoftwareInstallation { get; }
    public IReadOnlyList<DeviceModule> DeviceModules => _deviceModules.AsReadOnly();
    public IReadOnlyList<Camera> Cameras => _cameras.AsReadOnly();
    public IReadOnlyList<Deploy> Deploys => _deploys.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private PhysicalDevice(
        PhysicalDeviceId id,
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId,
        MetaData metaData,
        IoTHubDevice iotHubDevice,
        SoftwareInstallation softwareInstallation,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ) : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        TenantId = tenantId;
        MetaData = metaData;
        IoTHubDevice = iotHubDevice;
        SoftwareInstallation = softwareInstallation;
        TenantId = tenantId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static PhysicalDevice Create(
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId,
        MetaData metaData,
        IoTHubDevice iotHubDevice,
        SoftwareInstallation softwareInstallation
    )
    {
        return new(
            PhysicalDeviceId.CreateUnique(),
            name,
            description,
            status,
            tenantId,
            metaData,
            iotHubDevice,
            softwareInstallation,
            DateTime.Now,
            DateTime.Now
        );
    }
    public static void Update()
    {
        throw new NotImplementedException();
    }
    public static void Delete()
    {
        throw new NotImplementedException();
    }
    public static void AddModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }
    public static void UpdateModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }
    public static void RemoveModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }
    public static void AddCamera(Camera camera)
    {
        throw new NotImplementedException();
    }
    public static void UpdateCamera(Camera camera)
    {
        throw new NotImplementedException();
    }
    public static void RemoveCamera(Camera camera)
    {
        throw new NotImplementedException();
    }
    public static void CreateDeviceInIoTHub()
    {
        throw new NotImplementedException();
    }
    public static void InstallSoftware()
    {
        throw new NotImplementedException();
    }
    public static void DeployModules()
    {
        throw new NotImplementedException();
    }
}