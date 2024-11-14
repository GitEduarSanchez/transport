using MediatR;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Handle;

public class ControlViajeOrigenHandle(IControlViajeOrigenRepository _controlviajeorigenRepository) : IRequestHandler<CreateControlViajeOrigenCommand, bool>
{
    public async Task<bool> Handle(CreateControlViajeOrigenCommand request, CancellationToken cancellationToken)
    {
        ControlViajeOrigenEntity controlviajeorigen = new() { idcontrolviaje = request.idcontrolviaje, idorigen = request.idorigen, idciudad = request.ciudad };
        return await _controlviajeorigenRepository.SaveAsync(controlviajeorigen);
    }
}
