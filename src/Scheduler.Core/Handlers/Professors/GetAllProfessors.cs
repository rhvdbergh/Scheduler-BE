using MediatR;
using Scheduler.Core.Base;

namespace Scheduler.Core.Handlers.Professors;

public class GetAllProfessors : IRequestHandler<GetAllProfessors.Request, GetAllProfessors.Response[]>
{

    private readonly IProfessorRepository _professorRepository;
    
    public GetAllProfessors(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }

    public async Task<Response[]> Handle(Request request, CancellationToken cancellationToken)
    {
        var profs = await _professorRepository.GetAllProfessors(cancellationToken);
        return profs.Select(x => new Response(x.Id, x.Name)).ToArray();
    }
    public record Request() : IRequest<Response[]>
    {}

    public record Response(Guid Id, string Name)
    {
    }

}