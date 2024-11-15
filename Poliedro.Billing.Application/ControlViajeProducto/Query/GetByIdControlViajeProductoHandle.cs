using MediatR;
using Poliedro.Billing.Application.ControlViajeProducto.Dto;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;

namespace Poliedro.Billing.Application.ControlViajeProducto.Query;

public class GetByIdControlViajeProductoHandle(IControlViajeProductoRepository ControlViajeProductoRepository) : IRequestHandler<GetByIdControlViajeProductoQuery, ControlViajeProductoDto>
{
    public async Task<ControlViajeProductoDto> Handle(GetByIdControlViajeProductoQuery request, CancellationToken cancellationToken)
    {
        var getByIdControlViajeProducto = await ControlViajeProductoRepository.GetById(request.idControlViajeProducto);
        return new ControlViajeProductoDto(idControlViajeProducto: getByIdControlViajeProducto.idControlViajeProducto, idControlViaje: getByIdControlViajeProducto.idControlViaje,idProducto: getByIdControlViajeProducto.idProducto );
    }
}
