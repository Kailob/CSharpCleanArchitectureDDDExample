// <copyright file="CreateDeviceRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts.Device;

using Domain.DeviceAggregate.Enums;

/// <summary>
/// Create Device Command.
/// </summary>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <param name="MetaData">Device Meta Data.</param>
/// <param name="IoTHubDevice">IoT Device Data.</param>
/// <param name="Cameras">Cameras.</param>
/// <returns>CreateDeviceCommand.</returns>
public record CreateDeviceRequest(
    string Name,
    string Description,
    MetaDataRequest MetaData,
    IoTHubDeviceRequest IoTHubDevice,
    List<CameraItemRequest> Cameras);

/// <summary>
/// Device Meta Data.
/// </summary>
/// <param name="MacAddress">Mac Address.</param>
/// <param name="IpAddress">Ip Address.</param>
/// <param name="Username">Username.</param>
/// <param name="Password">Password.</param>
/// <param name="LinuxOS">Linux Version.</param>
/// <returns>MetaDataRequest.</returns>
public record MetaDataRequest(
    string MacAddress,
    string IpAddress,
    string Username,
    string Password,
    LinuxOS LinuxOS);

/// <summary>
/// IoT Device Data.
/// </summary>
/// <param name="Name">IoT Name.</param>
/// <returns>IoTHubDeviceRequest.</returns>
public record IoTHubDeviceRequest(string Name);

/// <summary>
/// Camera Item.
/// </summary>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <returns>CameraItemRequest.</returns>
public record CameraItemRequest(
    string Name,
    string Description);
