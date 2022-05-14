using MediatR;

namespace Scheduler.Core.Handlers.TimeSlots;

public class GenerateTimeSlots : IRequestHandler<GenerateTimeSlots.Request, GenerateTimeSlots.Response>
{
    public record Request
        (Guid SeasonId, int LectureLengthInMinutes, DateTime StartTime, int NumberOfBreaks) : IRequest<Response>;

    public record Response(string Message);

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        return new Response("success");
        throw new NotImplementedException();
    }
}