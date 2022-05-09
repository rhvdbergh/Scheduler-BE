using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Core.Handlers.Professors;

namespace Scheduler.Api.Controllers.Professors;

[ApiController]
[Route("[controller]")]
public class ProfessorsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProfessorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetProfessors")]
    public async Task<GetAllProfessors.Response[]> GetProfessors()
    {
        return await _mediator.Send(new GetAllProfessors.Request());
    }
}