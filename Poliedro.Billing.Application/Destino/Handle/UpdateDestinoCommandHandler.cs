using MediatR;
using Poliedro.Billing.Domain.Destino.Entities;
using Poliedro.Billing.Domain.Destino.Ports;

namespace Poliedro.Billing.Application.Destino.Commands.Handle;

public class UpdateDestinoCommandHandler(IDestinoRepository _destinoRepository) : IRequestHandler<UpdateDestinoCommand, Unit>
{
    public async Task<Unit> Handle(UpdateDestinoCommand request, CancellationToken cancellationToken)
    {
        var destino = await _destinoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        destino.Descripcion = request.DestinoEntity.Descripcion;
        await _destinoRepository.UpdateAsync(request.Id, new DestinoEntity() { Descripcion = destino.Descripcion});
        return Unit.Value;
    }
}
