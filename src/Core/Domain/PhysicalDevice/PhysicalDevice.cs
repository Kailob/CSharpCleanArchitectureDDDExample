using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.PhysicalDevice.Entities;
using Domain.PhysicalDevice.ValueObjects;
using Domain.Tenant.ValueObjects;

namespace Domain.PhysicalDevice;

/// <summary>
/// Physical Device aggregate.
/// </summary>
public sealed class PhysicalDevice : AggregateRoot<PhysicalDeviceId>
{
    private readonly List<DeviceModule> _deviceModules = new();
    private readonly List<Camera> _cameras = new();
    private readonly List<Deploy> _deploys = new();

    private PhysicalDevice(
        PhysicalDeviceId id,
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId,
        MetaData metaData,
        IoTDevice iotDevice,
        Software software,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        TenantId = tenantId;
        MetaData = metaData;
        IoTDevice = iotDevice;
        Software = software;
        TenantId = tenantId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    /// <summary>
    /// Gets name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; }

    /// <summary>
    /// Gets description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; }

    /// <summary>
    /// Gets entity status.
    /// </summary>
    /// <value>EntityStatus.</value>
    public EntityStatus Status { get; }

    /// <summary>
    /// Gets TenantId value object.
    /// </summary>
    /// <value>TenantId.</value>
    public TenantId TenantId { get; }

    /// <summary>
    /// Gets MetaData instance.
    /// </summary>
    /// <value>MetaData.</value>
    public MetaData MetaData { get; }

    /// <summary>
    /// Gets IoTDevice instance.
    /// </summary>
    /// <value>IoTDevice.</value>
    public IoTDevice IoTDevice { get; }

    /// <summary>
    /// Gets Software instance.
    /// </summary>
    /// <value>Software.</value>
    public Software Software { get; }

    /// <summary>
    /// Gets Device Modules list.
    /// </summary>
    /// <value>IReadOnlyList of DeviceModule.</value>
    public IReadOnlyList<DeviceModule> DeviceModules => _deviceModules.AsReadOnly();

    /// <summary>
    /// Gets Cameras list.
    /// </summary>
    /// <value>IReadOnlyList of Cameras.</value>
    public IReadOnlyList<Camera> Cameras => _cameras.AsReadOnly();

    /// <summary>
    /// Gets Cameras list.
    /// </summary>
    /// <value>IReadOnlyList of Deploys.</value>
    public IReadOnlyList<Deploy> Deploys => _deploys.AsReadOnly();

    /// <summary>
    /// Gets Physical Device CreateDateTime. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; }

    /// <summary>
    /// Gets Physical Device UpdateDateTime. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; }

    /// <summary>
    /// Creates new Physical Device instance.
    /// </summary>
    /// <param name="name">Device Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="status">Entity Status.</param>
    /// <param name="tenantId">TenantId.</param>
    /// <param name="metaData">Meta Data.</param>
    /// <param name="iotDevice">IoT Device Data.</param>
    /// <param name="software">Software Installation.</param>
    /// <returns>new PhysicalDevice instance.</returns>
    public static PhysicalDevice Create(
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId,
        MetaData metaData,
        IoTDevice iotDevice,
        Software software)
    {
        return new(
            PhysicalDeviceId.CreateUnique(),
            name,
            description,
            status,
            tenantId,
            metaData,
            iotDevice,
            software,
            DateTime.Now,
            DateTime.Now);
    }

    /// <summary>
    /// Update Physical Device.
    /// </summary>
    public static void Update()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete Physical Device.
    /// </summary>
    public static void Delete()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds Module to Physical Device.
    /// </summary>
    public static void AddModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update Physical Device Module.
    /// </summary>
    public static void UpdateModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete Physical Device Module.
    /// </summary>
    public static void DeleteModule(DeviceModule module)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds Camera to Physical Device.
    /// </summary>
    public static void AddCamera(Camera camera)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update Physical Device Camera.
    /// </summary>
    public static void UpdateCamera(Camera camera)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete Physical Device Camera.
    /// </summary>
    public static void DeleteCamera(Camera camera)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create Device in IoT Hub.
    /// </summary>
    public static void CreateDeviceInIoTHub()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Install Software in Physical Device.
    /// </summary>
    public static void InstallSoftware()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deploy Physical Device Modules using IoT Hub.
    /// </summary>
    public static void DeployModules()
    {
        throw new NotImplementedException();
    }
}
