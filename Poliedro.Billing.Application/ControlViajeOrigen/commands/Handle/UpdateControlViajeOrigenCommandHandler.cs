using MediatR;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Handle;

public class UpdateControlViajeOrigenCommandHandler(IControlViajeOrigenRepository _controlviajeorigenRepository) : IRequestHandler<UpdateControlViajeOrigenCommand, Unit>
{
    public async Task<Unit> Handle(UpdateControlViajeOrigenCommand request, CancellationToken cancellationToken)
    {
        var controlviajeorigen = await _controlviajeorigenRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        controlviajeorigen.Descripcion = request.ControlViajeOrigenEntity.Descripcion;
        await _controlviajeorigenRepository.UpdateAsync(request.Id, new ControlViajeOrigenEntity() { Descripcion = controlviajeorigen.Descripcion});
        return Unit.Value;
    }
}
