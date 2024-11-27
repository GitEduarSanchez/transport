using MediatR;
using Poliedro.Billing.Application.Origen.Dto;
using Poliedro.Billing.Domain.Origen.Ports;

namespace Poliedro.Billing.Application.Origen.Query;

public class GetByIdOrigenHandle(IOrigenRepository origenRepository) : IRequestHandler<GetByIdOrigenQuery, OrigenDto>
{
    public async Task<OrigenDto> Handle(GetByIdOrigenQuery request, CancellationToken cancellationToken)
    {
        var getByIdOrigen = await origenRepository.GetById(request.Id);
        return new OrigenDto(Id: getByIdOrigen.Id, descripcion: getByIdOrigen.descripcion);
    }
}
