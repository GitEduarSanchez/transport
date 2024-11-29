using MediatR;
using Poliedro.Billing.Application.Vehiculo.Dto;
using Poliedro.Billing.Domain.Vehiculo.Ports;

namespace Poliedro.Billing.Application.Vehiculo.Query;

public class GetByIdVehiculoHandle(IVehiculoRepository vehiculoRepository) : IRequestHandler<GetByIdVehiculoQuery, VehiculoDto>
{
    public async Task<VehiculoDto> Handle(GetByIdVehiculoQuery request, CancellationToken cancellationToken)
    {
        var getByIdVehiculo = await vehiculoRepository.GetById(request.idvehiculo);
        return new VehiculoDto(idvehiculo: getByIdVehiculo.idvehiculo, placa: getByIdVehiculo.placa,idmarca:getByIdVehiculo.idmarca, idtipovehiculo:getByIdVehiculo.idtipovehiculo );
    }
}
