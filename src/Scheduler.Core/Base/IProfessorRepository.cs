using Scheduler.Core.Handlers.Professors;
using Scheduler.Core.Models;

namespace Scheduler.Core.Base;

public interface IProfessorRepository
{
    Task<IReadOnlyList<Professor>> GetAllProfessors(CancellationToken cancellationToken);
}