using Microsoft.AspNetCore.Mvc;
using Scheduler.Core.Models;
using Scheduler.Infra.Sql.Base;

namespace Scheduler.Api.Controllers.Professors;

[ApiController]
[Route("[controller]")]
public class ProfessorsController : ControllerBase
{
    private SchedulerDbContext _context { get; set; }
    public ProfessorsController(SchedulerDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetProfessors")]
    public IEnumerable<Professor> Get()
    {
        var Prof = _context.Professors;
        return Prof;
    }
}