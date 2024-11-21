using MediatR;
using Poliedro.Billing.Application.pais.Dto;
using Poliedro.Billing.Domain.pais.Entities.Ports;

namespace Poliedro.Billing.Application.pais.Query;

public class GetByIdpaisHandle(IpaisRepository paisRepository) : IRequestHandler<GetByIdpaisQuery, paisDto>
{
    public async Task<paisDto> Handle(GetByIdpaisQuery request, CancellationToken cancellationToken)
    {
        var getByIdpais = await paisRepository.GetById(request.Id);
        return new paisDto(Id: getByIdpais.Id, Descripcion: getByIdpais.Descripcion);
    }
}
