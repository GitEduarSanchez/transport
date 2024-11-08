using MediatR;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Estado.Entities.Ports;

namespace Poliedro.Billing.Application.Estado.Commands.Handle;

public class UpdateEstadoCommandHandler(IEstadoRepository _estadoRepository) : IRequestHandler<UpdateEstadoCommand, Unit>
{
    public async Task<Unit> Handle(UpdateEstadoCommand request, CancellationToken cancellationToken)
    {
        var estado = await _estadoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        estado.Descripcion = request.EstadoEntity.Descripcion;
        await _estadoRepository.UpdateAsync(request.Id, new EstadoEntity() { Descripcion = estado.Descripcion});
        return Unit.Value;
    }
}
