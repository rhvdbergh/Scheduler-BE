using Microsoft.EntityFrameworkCore;
using Scheduler.Core.Base;
using Scheduler.Core.Handlers.Professors;
using Scheduler.Core.Models;
using Scheduler.Infra.Sql.Base;

namespace Scheduler.Infra.Sql.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly SchedulerDbContext _context;

    public ProfessorRepository(SchedulerDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Professor>> GetAllProfessors(CancellationToken cancellationToken)
    {
        return await _context.Professors.ToListAsync(cancellationToken);
    }
}