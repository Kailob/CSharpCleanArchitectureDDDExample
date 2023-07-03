namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// IoT Device Entity.
/// </summary>
public sealed class IoTDevice
{
    private IoTDevice(
        string name)
    {
        Name = name;
    }

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private IoTDevice()
    {

    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets Name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; private set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="IoTDevice"/> entity.
    /// </summary>
    /// <param name="name">string.</param>
    /// <returns>IoTDevice.</returns>
    public static IoTDevice Create(
        string name)
    {
        return new(
            name);
    }
}
