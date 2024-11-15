using MediatR;
using Poliedro.Billing.Application.Descargue.Dto;
using Poliedro.Billing.Domain.Descargue.Ports;

namespace Poliedro.Billing.Application.Descargue.Query;

public class GetAllActuatorHandle(IDescargueRepository _DescargueRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<DescargueDto>>
{
    public async Task<IEnumerable<DescargueDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _DescargueRepository.GetAllAsync();
        return entities.Select(Descargue => new DescargueDto
        (
            iddescargue: Descargue.iddescargue,
            descriocion: Descargue.descriocion
        ));
    }
}
