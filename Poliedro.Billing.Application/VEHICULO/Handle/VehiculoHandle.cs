using MediatR;
using Poliedro.Billing.Application.Estado.Commands;
using Poliedro.Billing.Domain.Vehiculo.Entities;
using Poliedro.Billing.Domain.Vehiculo.Ports;

namespace Poliedro.Billing.Application.Vehiculo.Commands.Handle;

public class VehiculoHandle(IVehiculoRepository _VehiculoRepository) : IRequestHandler<CreateVehiculoCommand, bool>
{
    public async Task<bool> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {
        VehiculoEntity Vehiculio = new() { placa = request.placa, idmarca = request.idmarca, idtipovehiculo = request.idtipovehiculo };
        return await _VehiculoRepository.SaveAsync(vehiculo);
    }
}
