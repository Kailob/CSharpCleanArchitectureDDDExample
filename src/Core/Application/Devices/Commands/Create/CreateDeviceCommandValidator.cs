using FluentValidation;

namespace Application.Devices.Commands.Create;

/// <summary>
/// Register Command Validator.
/// </summary>
public class CreateDeviceCommandValidator : AbstractValidator<CreateDeviceCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDeviceCommandValidator"/> class.
    /// </summary>
    public CreateDeviceCommandValidator()
    {
        RuleFor(x => x.IoTHubDevice.Name).NotEmpty();
        RuleFor(x => x.MetaData.MacAddress).NotEmpty();
        RuleFor(x => x.MetaData.IpAddress).NotEmpty();
        RuleFor(x => x.MetaData.Username).NotEmpty();
        RuleFor(x => x.MetaData.Password).NotEmpty();
        RuleFor(x => x.MetaData.LinuxOS).NotEmpty();
        RuleFor(x => x.Cameras).NotEmpty();
    }
}
