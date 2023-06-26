using Domain.DeviceAggregate;

namespace Application.Common.Interfaces.Persistence;

/// <summary>
/// Device Repository Interface.
/// </summary>
public interface IDeviceRepository
{
    /// <summary>
    /// Add Device.
    /// </summary>
    /// <param name="device"></param>
    void Add(Device device);
}