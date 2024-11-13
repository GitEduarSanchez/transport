using MediatR;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Dto;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Query;

public class GetAllEstadoQueryHandle(IControlViajeOrigenRepository _controlviajeorigenRepository) : IRequestHandler<GetAllControlViajeOrigenQuery, IEnumerable<ControlViajeOrigenDto>>
{
    public async Task<IEnumerable<ControlViajeOrigenDto>> Handle(GetAllControlViajeOrigenQuery request, CancellationToken cancellationToken)
    {
        var entities = await _controlviajeorigenRepository.GetAllAsync();
        return entities.Select(controlviajeorigen => new ControlViajeOrigenDto
        (
            Id: controlviajeorigen.Id,
            Descripcion: controlviajeorigen.Descripcion
        ));
    }
}
