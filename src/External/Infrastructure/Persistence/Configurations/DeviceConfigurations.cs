using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Domain.DeviceAggregate;
using Domain.DeviceAggregate.Entities;
using Domain.DeviceAggregate.ValueObjects;
using Domain.ModuleAggregate.ValueObjects;
using Domain.StoreAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

/// <summary>
/// Device EF configurations.
/// </summary>
public class DeviceConfigurations : IEntityTypeConfiguration<Device>
{
    /// <summary>
    /// Device Configuration.
    /// </summary>
    /// <param name="builder">Device EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        ConfigureDevicesTables(builder);
        ConfigureDeviceCamerasTables(builder);
        ConfigureDeviceModulesTables(builder);
        ConfigureDeviceDeploysTables(builder);
        ConfigureDeviceSoftwareTables(builder);
    }

    private void ConfigureDevicesTables(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("Devices");

        builder.HasKey(nameof(Device.Id));

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DeviceId.Create(value));
        builder.Property(x => x.Name)
            .HasMaxLength(128);

        builder.Property(x => x.Description)
            .HasMaxLength(255);

        // MetaData
        builder.OwnsOne(x => x.MetaData, mdb =>
        {
            mdb.Property(m => m.MacAddress)
                .HasColumnName("MacAddress")
                .HasMaxLength(17);
            mdb.Property(m => m.IpAddress)
                .HasColumnName("IpAddress")
                .HasMaxLength(15);
            mdb.Property(m => m.Username)
                .HasColumnName("Username")
                .HasMaxLength(20);
            mdb.Property(m => m.Password)
                .HasColumnName("Password")
                .HasMaxLength(50);
            mdb.Property(m => m.LinuxOS)
                .HasColumnName("LinuxOS");
        });

        // IoT Device Meta
        builder.OwnsOne(x => x.IoTDevice, ib =>
        {
            ib.Property(m => m.Name)
                .HasColumnName("IoTDeviceName")
                .HasMaxLength(17);
        });

        builder.Property(x => x.StoreId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => StoreId.Create(value));

        builder.Property(x => x.Status);
    }

    private void ConfigureDeviceCamerasTables(EntityTypeBuilder<Device> builder)
    {
        builder.OwnsMany(x => x.Cameras, cb =>
        {
            cb.ToTable("Cameras");

            cb.HasKey(nameof(Camera.Id));
            cb.WithOwner().HasForeignKey("DeviceId");

            cb.Property(x => x.Id)
                .HasColumnName("CameraId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CameraId.Create(value));

            cb.Property(x => x.Name)
                .HasMaxLength(128);

            cb.Property(x => x.Description)
                .HasMaxLength(255);
        });

        builder.Metadata.FindNavigation(nameof(Device.Cameras))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDeviceDeploysTables(EntityTypeBuilder<Device> builder)
    {
        builder.OwnsMany(x => x.Deploys, cb =>
        {
            cb.ToTable("DeviceDeploys");

            cb.HasKey(nameof(Deploy.Id));
            cb.WithOwner().HasForeignKey("DeviceId");

            cb.Property(x => x.Id)
                .HasColumnName("DeviceDeployId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DeployId.Create(value));

            cb.Property(x => x.Manifest);
        });

        builder.Metadata.FindNavigation(nameof(Device.Deploys))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDeviceModulesTables(EntityTypeBuilder<Device> builder)
    {
        builder.OwnsMany(x => x.DeviceModules, cb =>
        {
            cb.ToTable("DeviceModules");

            cb.HasKey(nameof(DeviceModule.Id));
            // cb.WithOwner().HasForeignKey("DeviceId", "ModuleId");
            cb.WithOwner().HasForeignKey("DeviceId");

            cb.Property(x => x.Id)
                .HasColumnName("DeviceModuleId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DeviceModuleId.Create(value));

            cb.Property(x => x.Variables);

            cb.Property(x => x.ModuleId)
                // .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ModuleId.Create(value));

        });

        builder.Metadata.FindNavigation(nameof(Device.DeviceModules))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDeviceSoftwareTables(EntityTypeBuilder<Device> builder)
    {
        builder.OwnsMany(x => x.SoftwareInstallations, cb =>
        {
            cb.ToTable("DeviceSoftware");

            cb.HasKey(nameof(Software.Id));
            cb.WithOwner().HasForeignKey("DeviceId");

            cb.Property(x => x.Id)
                .HasColumnName("DeviceSoftwareId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SoftwareId.Create(value));

            cb.Property(x => x.Log);
        });

        builder.Metadata.FindNavigation(nameof(Device.SoftwareInstallations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}