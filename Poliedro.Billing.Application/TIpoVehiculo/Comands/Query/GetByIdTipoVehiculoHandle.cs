using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Query;

public class GetByIdTipoVehiculoHandle(ITipoVehiculoRepository TipoVehiculoRepository) : IRequestHandler<GetByIdTipoVehiculoQuery, TipoVehiculoDto>
{
    public async Task<TipoVehiculoDto> Handle(GetByIdTipoVehiculoQuery request, CancellationToken cancellationToken)
    {
        var getByIdTipoVehiculo = await TipoVehiculoRepository.GetById(request.Id);
        return new TipoVehiculoDto(Id: getByIdTipoVehiculo.id, descripcion: getByIdTipoVehiculo.descripcion);
    }
}
