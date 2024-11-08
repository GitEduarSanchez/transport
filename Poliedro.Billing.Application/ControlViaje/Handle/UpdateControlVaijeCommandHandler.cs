using MediatR;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViaje.Commands.Handle;

public class UpdateEstadoCommandHandler(IControlViajeRepository _controlviajeRepository) : IRequestHandler<UpdateControlViajeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateControlViajeCommand request, CancellationToken cancellationToken)
    {
        var controlvaije = await _controlviajeRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        controlvaije.guia = request.ControlViajeEntity.guia;
        controlvaije.fecha = request.ControlViajeEntity.fecha;
        controlvaije.idVehiculoTrailer = request.ControlViajeEntity.idVehiculoTrailer;
        await _controlviajeRepository.UpdateAsync(request.Id, new ControlViajeEntity() {guia = controlvaije.guia, fecha = controlvaije.fecha, idVehiculoTrailer = controlvaije.idVehiculoTrailer});
        return Unit.Value;
    }
}
