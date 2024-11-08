using MediatR;
using Poliedro.Billing.Application.ControlViaje.Dto;
using Poliedro.Billing.Domain.ControlViaje.Ports;

namespace Poliedro.Billing.Application.ControlViaje.Query;

public class GetByIdConductorHandle(IControlViajeRepository controlviajeRepository) : IRequestHandler<GetByIdControlViajeQuery, ControlViajeDto>
{
    public async Task<ControlViajeDto> Handle(GetByIdControlViajeQuery request, CancellationToken cancellationToken)
    {
        var getByIdControlViaje = await controlviajeRepository.GetById(request.idControlViaje);
        return new ControlViajeDto(idControlViaje: getByIdControlViaje.idControlViaje, fecha: getByIdControlViaje.fecha,idVehiculoTrailer: getByIdControlViaje.idVehiculoTrailer,guia:getByIdControlViaje.guia);
    }
}
