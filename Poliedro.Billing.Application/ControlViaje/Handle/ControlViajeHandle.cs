using MediatR;
using Poliedro.Billing.Application.ControlViaje.Commands;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViaje.Handle;

public class ControlViajeHandle(IControlViajeRepository _controlviajeRepository) : IRequestHandler<CreateControlViajeCommand, bool>
{
    public async Task<bool> Handle(CreateControlViajeCommand request, CancellationToken cancellationToken)
    {
        ControlViajeEntity controlviaje = new ControlViajeEntity() {fecha = request.fecha, guia = request.guia, idVehiculoTrailer = request.idVehiculoTrailer};
        return await _controlviajeRepository.SaveAsync(controlviaje);
    }
}
