using MediatR;
using Poliedro.Billing.Application.unidad_medida.Dto;
using Poliedro.Billing.Domain.unidad_medida.Ports;

namespace Poliedro.Billing.Application.unidad_medida.Query;

public class GetAllActuatorHandle(Iunidad_medidaRepository _unidad_medidaRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<unidad_medidaDto>>
{
    public async Task<IEnumerable<unidad_medidaDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unidad_medidaRepository.GetAllAsync();
        return entities.Select(unidad_medida => new unidad_medidaDto
        (
            Id: unidad_medida.Id,
            descripcion: unidad_medida.descripcion
        
        ));
    }
}
