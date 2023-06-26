using Application.Devices.Commands;
using Contracts.Device;
using Domain.DeviceAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("tenants/{tenantId}/stores/{storeId}/devices")]
public class DevicesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public DevicesController(
        IMapper mapper,
        ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDevice(
        CreateDeviceRequest request,
        string tenantId,
        string storeId)
    {
        var command = _mapper.Map<CreateDeviceCommand>((request, storeId));
        ErrorOr<Device> response = await _mediator.Send(command);

        return response.Match(
            device => Ok(_mapper.Map<DeviceResponse>(device)),
            // device => CreatedAtAction(nameof(GetDevice), new { tenantId, storeId, device}),
            errors => Problem(errors));
    }
}
