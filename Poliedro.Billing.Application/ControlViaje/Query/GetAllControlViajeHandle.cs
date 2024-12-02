using MediatR;
using Poliedro.Billing.Application.ControlViaje.Dto;
using Poliedro.Billing.Domain.ControlViaje.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViaje.Commands.Query;

public class GetAllControlViajeQueryHandle(IControlViajeRepository _controlviajeRepository) : IRequestHandler<GetAllControlViajeQuery, IEnumerable<ControlViajeDto>>
{
    public async Task<IEnumerable<ControlViajeDto>> Handle(GetAllControlViajeQuery request, CancellationToken cancellationToken)
    {
        var entities = await _controlviajeRepository.GetAllAsync();
        return entities.Select(controlviaje => new ControlViajeDto
        (
            idControlViaje: controlviaje.idControlViaje,
            fecha: controlviaje.fecha, 
            guia: controlviaje.guia,
            idVehiculoTrailer: controlviaje.idVehiculoTrailer
        ));
    }
}
