using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Handle;

public class TipoVehiculoHandle(ITipoVehiculoRepository _tipovehiculoRepository) : IRequestHandler<CreateTipoVehiculoCommand, bool>
{
    public async Task<bool> Handle(CreateTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        TipoVehiculoEntity tipovehiculo = new() { descripcion = request.Descripcion};
        return await _tipovehiculoRepository.SaveAsync(tipovehiculo);
    }
}
