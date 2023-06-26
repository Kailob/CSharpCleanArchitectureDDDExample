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
    }
}
