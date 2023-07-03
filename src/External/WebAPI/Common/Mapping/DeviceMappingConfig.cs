using Application.Devices.Commands;
using Contracts.Device;
using Domain.DeviceAggregate;
using Domain.DeviceAggregate.Entities;
using Domain.StoreAggregate.ValueObjects;
using Mapster;

namespace WebAPI.Common.Mapping;

public class DeviceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateDeviceRequest Request, string StoreId), CreateDeviceCommand>()
            .Map(dest => dest.MetaData, source => source.Request.MetaData)
            .Map(dest => dest.IoTHubDevice, source => source.Request.IoTHubDevice)
            .Map(dest => dest.Cameras, source => source.Request.Cameras)
            .Map(dest => dest.Name, source => source.Request.Name)
            .Map(dest => dest.Description, source => source.Request.Description)
            .Map(dest => dest.StoreId, source => StoreId.Create(new Guid(source.StoreId)));

        config.NewConfig<Device, DeviceResponse>()
            .Map(dest => dest.Id, source => source.Id.Value)
            .Map(dest => dest.StoreId, source => source.StoreId.Value);

        // .Map(dest=> dest.Deploys, src => src.DeployIds.Select(deploy));

        config.NewConfig<MetaData, MetaDataResponse>();
        config.NewConfig<IoTDevice, IoTHubDeviceResponse>();
        config.NewConfig<Camera, CameraItemResponse>()
            .Map(dest => dest.Id, source => source.Id.Value);

    }
}
