using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands.Query;

public class GetAllTipoVehiculoQueryHandle(ITipoVehiculoRepository _tipovehiculoRepository) : IRequestHandler<GetAllTipoVehiculoQuery, IEnumerable<TipoVehiculoDto>>
{
    public async Task<IEnumerable<TipoVehiculoDto>> Handle(GetAllTipoVehiculoQuery request, CancellationToken cancellationToken)
    {
        var entities = await _tipovehiculoRepository.GetAllAsync();
        return entities.Select(tipovehiculo => new TipoVehiculoDto
        (
            id: tipovehiculo.Id,
            descripcion: tipovehiculo.descripcion
        ));
    }
}
