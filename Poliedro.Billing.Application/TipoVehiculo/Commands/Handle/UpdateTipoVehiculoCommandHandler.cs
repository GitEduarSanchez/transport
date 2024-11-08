using MediatR;
using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Entities.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands.Handle;

public class UpdateTipoVehiculoCommandHandler(ITipoVehiculoRepository _tipovehiculoRepository) : IRequestHandler<UpdateTipoVehiculoCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var tipovehiculo = await _tipovehiculoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        tipovehiculo.Descripcion = request.TipoVehiculoEntity.descripcion;
        await _tipovehiculoRepository.UpdateAsync(request.Id, new TipoVehiculoEntity() { descripcion = tipovehiculo.Descripcion});
        return Unit.Value;
    }
}
