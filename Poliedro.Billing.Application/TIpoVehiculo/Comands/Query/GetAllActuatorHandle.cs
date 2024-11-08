using MediatR;
using Poliedro.Billing.Application.Ciudad.Dto;
using Poliedro.Billing.Domain.Ciudad.Ports;

namespace Poliedro.Billing.Application.Ciudad.Query;

public class GetAllActuatorHandle(ICiudadRepository _ciudadRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<CiudadDto>>
{
    public async Task<IEnumerable<CiudadDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _ciudadRepository.GetAllAsync();
        return entities.Select(ciudad => new CiudadDto
        (
            Id: ciudad.Id,
            Descripcion: ciudad.Descripcion,
            Iddepartamento: ciudad.Iddepartamento
        ));
    }
}
