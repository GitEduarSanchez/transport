using MediatR;
using Poliedro.Billing.Domain.controlviaje_origen.Entities;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Handle;

public class Updatecontrolviaje_origenCommandHandler(Icontrolviaje_origenRepository _controlviaje_origenRepository) : IRequestHandler<Updatecontrolviaje_origenCommand, Unit>
{
    public async Task<Unit> Handle(Updatecontrolviaje_origenCommand request, CancellationToken cancellationToken)
    {
        var controlviaje_origen = await _controlviaje_origenRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        controlviaje_origen.idcontrolviaje = request.controlviaje_origenEntity.idcontrolviaje;
        controlviaje_origen.idorigen = request.controlviaje_origenEntity.idorigen;
        controlviaje_origen.idciudad = request.controlviaje_origenEntity.idciudad;
        await _controlviaje_origenRepository.UpdateAsync(request.Id, new controlviaje_origenEntity() { idcontrolviaje = controlviaje_origen.idcontrolviaje, idorigen = controlviaje_origen.idorigen, idciudad = controlviaje_origen.idciudad});
        return Unit.Value;
    }
}
