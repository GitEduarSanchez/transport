using MediatR;
using Poliedro.Billing.Domain.Trailer.Ports;

namespace Poliedro.Billing.Application.Trailer.Commands.Handle;

public class DeleteEntityCommandHandler(ITrailerRepository TrailerRepository) : IRequestHandler<DeleteTrailerCommand, bool>
{
    public async Task<bool> Handle(DeleteTrailerCommand request, CancellationToken cancellationToken)
    {
        return await TrailerRepository.DeleteAsync(request.Id);
    }
}
