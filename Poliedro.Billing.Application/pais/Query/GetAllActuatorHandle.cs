using MediatR;
using Poliedro.Billing.Application.pais.Dto;
using Poliedro.Billing.Domain.pais.Entities.Ports;

namespace Poliedro.Billing.Application.pais.Query;

public class GetAllActuatorHandle(IpaisRepository _paisRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<paisDto>>
{
    public async Task<IEnumerable<paisDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _paisRepository.GetAllAsync();
        return entities.Select(pais => new paisDto
        (
            Id: pais.Id,
            Descripcion: pais.Descripcion
            
        ));
    }
}
