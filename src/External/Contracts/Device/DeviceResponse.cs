// <copyright file="DeviceResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Domain.DeviceAggregate.Enums;

namespace Contracts.Device;

/// <summary>
/// Create Device Response.
/// </summary>
/// <param name="Id">Device Id.</param>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <param name="StoreId">Store Id.</param>
/// <param name="MetaData">Device Meta Data Response.</param>
/// <param name="IoTHubDevice">IoT Device Data Response.</param>
/// <param name="Cameras">Cameras Response.</param>
/// <param name="CreatedDateTime">Created DateTime.</param>
/// <param name="UpdatedDateTime">Updated DateTime.</param>
/// <returns>DeviceResponse.</returns>
public record DeviceResponse(
    Guid Id,
    string Name,
    string Description,
    Guid StoreId,
    MetaDataResponse MetaData,
    IoTHubDeviceResponse IoTHubDevice,
    List<CameraItemResponse> Cameras,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

/// <summary>
/// Device Meta Data.
/// </summary>
/// <param name="MacAddress">Mac Address.</param>
/// <param name="IpAddress">Ip Address.</param>
/// <param name="Username">Username.</param>
/// <param name="Password">Password.</param>
/// <param name="LinuxOS">Linux Version.</param>
/// <param name="CreatedDateTime">Created DateTime.</param>
/// <param name="UpdatedDateTime">Updated DateTime.</param>
/// <returns>MetaDataResponse.</returns>
public record MetaDataResponse(
    string MacAddress,
    string IpAddress,
    string Username,
    string Password,
    LinuxOS LinuxOS,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

/// <summary>
/// IoT Device Data.
/// </summary>
/// <param name="Name">IoT Name.</param>
/// <param name="CreatedDateTime">Created DateTime.</param>
/// <returns>IoTHubDevice.</returns>
public record IoTHubDeviceResponse(
    string Name,
    DateTime CreatedDateTime);

/// <summary>
/// Camera Item.
/// </summary>
/// <param name="Id">Device Id.</param>
/// <param name="Name">Name.</param>
/// <param name="Description">Description.</param>
/// <param name="CreatedDateTime">Created DateTime.</param>
/// <param name="UpdatedDateTime">Updated DateTime.</param>
/// <returns>CameraItem.</returns>
public record CameraItemResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);
