using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Core.Handlers.TimeSlots;

namespace Scheduler.Api.Controllers.Professors;

[ApiController]
[Route("[controller]")]
public class SeasonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeasonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "GenerateTimeSlots")]
    public async Task<GenerateTimeSlots.Response> GenerateTimeSlots([FromBody] GenerateTimeSlots.Request request)

    {
        return await _mediator.Send(request);
    }
}