using MediatR;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Dto;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Query;

public class GetAllEstadoQueryHandle(Icontrolviaje_origenRepository _controlviaje_origenRepository) : IRequestHandler<GetAllcontrolviaje_origenQuery, IEnumerable<controlviaje_origenDto>>
{
    public async Task<IEnumerable<controlviaje_origenDto>> Handle(GetAllcontrolviaje_origenQuery request, CancellationToken cancellationToken)
    {
        var entities = await _controlviaje_origenRepository.GetAllAsync();
        return entities.Select(controlviaje_origen => new controlviaje_origenDto
        (
            idcontrolviaje_origen: controlviaje_origen.idcontrolviaje_origen,
            idcontrolviaje: controlviaje_origen.idcontrolviaje,
            idciudad: controlviaje_origen.idciudad,
            idorigen: controlviaje_origen.idorigen
        ));
    }
}
