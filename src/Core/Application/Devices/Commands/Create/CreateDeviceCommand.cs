using Domain.DeviceAggregate;
using Domain.DeviceAggregate.Enums;
using Domain.StoreAggregate.ValueObjects;
using ErrorOr;

using MediatR;

namespace Application.Devices.Commands;

/// <summary>
/// Create Device Command.
/// </summary>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <param name="StoreId">Store Id.</param>
/// <param name="MetaData">Device Meta Data.</param>
/// <param name="IoTHubDevice">IoT Device Data.</param>
/// <param name="Cameras">Cameras.</param>
/// <returns>CreateDeviceCommand.</returns>
public record CreateDeviceCommand(
    string Name,
    string Description,
    StoreId StoreId,
    MetaDataCommand MetaData,
    IoTHubDeviceCommand IoTHubDevice,
    List<CameraItem> Cameras)
    : IRequest<ErrorOr<Device>>;

/// <summary>
/// Device Meta Data.
/// </summary>
/// <param name="MacAddress">Mac Address.</param>
/// <param name="IpAddress">Ip Address.</param>
/// <param name="Username">Username.</param>
/// <param name="Password">Password.</param>
/// <param name="LinuxOS">Linux Version.</param>
/// <returns>MetaDataCommand.</returns>
public record MetaDataCommand(
    string MacAddress,
    string IpAddress,
    string Username,
    string Password,
    LinuxOS LinuxOS);

/// <summary>
/// IoT Device Data.
/// </summary>
/// <param name="Name">IoT Name.</param>
/// <returns>IoTHubDeviceCommand.</returns>
public record IoTHubDeviceCommand(string Name);

/// <summary>
/// Camera Item.
/// </summary>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <returns>CameraItem.</returns>
public record CameraItem(
    string Name,
    string Description);
