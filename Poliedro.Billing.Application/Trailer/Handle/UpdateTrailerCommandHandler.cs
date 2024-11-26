using MediatR;
using Poliedro.Billing.Domain.Trailer.Entities;
using Poliedro.Billing.Domain.Trailer.Ports;

namespace Poliedro.Billing.Application.Trailer.Commands.Handle;

public class UpdateTrailerCommandHandler(ITrailerRepository _trailerRepository) : IRequestHandler<UpdateTrailerCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTrailerCommand request, CancellationToken cancellationToken)
    {
        var trailer = await _trailerRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        trailer.Descripcion = request.TrailerEntity.descripcion;
        await _trailerRepository.UpdateAsync(request.Id, new TrailerEntity() { descripcion = trailer.Descripcion});
        return Unit.Value;
    }
}
