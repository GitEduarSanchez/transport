using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Query;

public class GetAllActuatorHandle(ITipoVehiculoRepository _tipovehiculoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<TipoVehiculoDto>>
{
    public async Task<IEnumerable<TipoVehiculoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _tipovehiculoRepository.GetAllAsync();
        return entities.Select(tipovehiculo => new TipoVehiculoDto
        (
            id: tipovehiculo.IdTipoVehiculo,
            descripcion: tipovehiculo.descripcion
           
        ));
    }
}
