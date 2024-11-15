using MediatR;
using Poliedro.Billing.Application.controlviaje_origen.Commands;
using Poliedro.Billing.Domain.controlviaje_origen.Entities;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Handle;

public class controlviaje_origenHandle(Icontrolviaje_origenRepository _controlviaje_origenRepository) : IRequestHandler<Createcontrolviaje_origenCommand, bool>
{
    public async Task<bool> Handle(Createcontrolviaje_origenCommand request, CancellationToken cancellationToken)
    {
        controlviaje_origenEntity controlviaje_origen = new() { idcontrolviaje = request.idcontrolviaje, idorigen = request.idorigen, idciudad = request.idciudad };
        return await _controlviaje_origenRepository.SaveAsync(controlviaje_origen);
    }
}
