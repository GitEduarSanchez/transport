using MediatR;
using Poliedro.Billing.Application.ControlViajeProducto.Dto;
using Poliedro.Billing.Application.ControlViajeProducto.Query;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;

namespace Poliedro.Billing.Application.Conductor.Query;

public class GetAllControlViajeProductoHandle(IControlViajeProductoRepository _conductorRepository) : IRequestHandler<GetAllControlViajeProductoQuery, IEnumerable<ControlViajeProductoDto>>
{
    public async Task<IEnumerable<ControlViajeProductoDto>> Handle(GetAllControlViajeProductoQuery request, CancellationToken cancellationToken)
    {
        var entities = await _conductorRepository.GetAllAsync();
        return entities.Select(ControlViajeProducto => new ControlViajeProductoDto
        (
            idControlViajeProducto: ControlViajeProducto.idControlViajeProducto,
            idControlViaje: ControlViajeProducto.idControlViaje,
            idProducto: ControlViajeProducto.idProducto
        ));
    }
}
