using MediatR;
using Poliedro.Billing.Application.Vehiculo.Dto;
using Poliedro.Billing.Domain.Vehiculo.Ports;

namespace Poliedro.Billing.Application.Vehiculo.Query;

public class GetAllActuatorHandle(IVehiculoRepository _vehiculoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<VehiculoDto>>
{
    public async Task<IEnumerable<VehiculoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _vehiculoRepository.GetAllAsync();
        return entities.Select(vehiculo => new VehiculoDto
        (
            idvehiculo: vehiculo.idvehiculo,
            placa: vehiculo.placa,
            idmarca: vehiculo.idmarca,
            idtipovehiculo: vehiculo.idtipovehiculo
           
        ));
    }
}
