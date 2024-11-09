using MediatR;
using Poliedro.Billing.Application.Origen.Dto;
using Poliedro.Billing.Domain.Origen.Entities.Ports;


namespace Poliedro.Billing.Application.Origen.Query;

public class GetAllActuatorHandle(IOrigenRepository _origenRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<OrigenDto>>
{
    public async Task<IEnumerable<OrigenDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _origenRepository.GetAllAsync();
        return entities.Select(origen => new OrigenDto
        (
            Id: origen.Id,
            descripcion: origen.descripcion
           
        ));
    }
}
