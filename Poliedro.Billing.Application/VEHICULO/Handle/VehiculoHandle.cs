using MediatR;
using Poliedro.Billing.Application.Estado.Commands;
using Poliedro.Billing.Domain.Vehiculo.Entities;
using Poliedro.Billing.Domain.Vehiculo.Entities.Ports;

namespace Poliedro.Billing.Application.Vehiculo.Commands.Handle;

public class VehiculoHandle(IVehiculoRepository _vehiculoRepository) : IRequestHandler<CreateVehiculoCommand, bool>
{
    public async Task<bool> Handle(CreateVrhiculoCommand request, CancellationToken cancellationToken)
    {
        VehiculoEntity estado = new() { Descripcion = request.Descripcion };
        return await _estadoRepository.SaveAsync(estado);
    }
}
