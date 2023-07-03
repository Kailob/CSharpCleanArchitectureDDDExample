using Application.Common.Interfaces.Persistence;
using Domain.DeviceAggregate;

namespace Infrastructure.Persistence.Repositories;

/// <summary>
/// Device Repository. IDeviceRepository implementation.
/// </summary>
public class DeviceRepository
    : IDeviceRepository
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceRepository"/> class.
    /// </summary>
    /// <param name="dbContext"></param>
    public DeviceRepository(AppDbContext dbContext) => _dbContext = dbContext;

    /// <summary>
    /// Add Device to database.
    /// </summary>
    /// <param name="device">Device Aggregate.</param>
    void IDeviceRepository.Add(Device device)
    {
        _dbContext.Add(device);
        _dbContext.SaveChanges();
    }
}