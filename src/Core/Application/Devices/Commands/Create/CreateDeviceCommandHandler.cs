namespace Application.Devices.Commands.Create;

using Application.Common.Interfaces.Persistence;
using Domain.Common.Enums;
using Domain.DeviceAggregate;
using Domain.DeviceAggregate.Entities;
using ErrorOr;
using MediatR;

/// <summary>
/// Create Device Command Handler.
/// </summary>
public class CreateDeviceCommandHandler :
    IRequestHandler<CreateDeviceCommand, ErrorOr<Device>>
{
    private readonly IDeviceRepository _deviceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDeviceCommandHandler"/> class.
    /// </summary>
    public CreateDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    /// <summary>
    /// Handles Command.
    /// </summary>
    /// <param name="request">CreateDeviceCommand request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Error Or Device.</returns>
    public async Task<ErrorOr<Device>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create Device
        var device = Device.Create(
            request.Name,
            request.Description,
            EntityStatus.Inactive,
            request.StoreId,
            MetaData.Create(
                request.MetaData.MacAddress,
                request.MetaData.IpAddress,
                request.MetaData.Username,
                request.MetaData.Password,
                request.MetaData.LinuxOS),
            IoTDevice.Create(
                request.IoTHubDevice.Name),
            request.Cameras.ConvertAll(
                requestCamera => Camera.Create(requestCamera.Name, requestCamera.Description)));

        // Persist Device
        _deviceRepository.Add(device);

        return device;
        // return default!;

    }
}
