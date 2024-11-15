using MediatR;
using Poliedro.Billing.Application.Descargue.Dto;
using Poliedro.Billing.Domain.Descargue.Ports;

namespace Poliedro.Billing.Application.Descargue.Query;

public class GetByiddescargueHandle(IDescargueRepository DescargueRepository) : IRequestHandler<GetByiddescargueQuery, DescargueDto>
{
    public async Task<DescargueDto> Handle(GetByiddescargueQuery request, CancellationToken cancellationToken)
    {
        var getByiddescargue = await DescargueRepository.GetById(request.iddescargue);
        return new DescargueDto(iddescargue: getByiddescargue.iddescargue, descriocion: getByiddescargue.descriocion);
    }
}
