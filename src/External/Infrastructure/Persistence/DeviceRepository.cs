using Application.Common.Interfaces.Persistence;
using Domain.DeviceAggregate;

namespace Infrastructure.Persistence;

/// <summary>
/// Device Repository. IDeviceRepository implementation.
/// </summary>
public class DeviceRepository
    : IDeviceRepository
{
    private static readonly List<Device> _devices = new();

    void IDeviceRepository.Add(Device device)
    {
        _devices.Add(device);
    }
}