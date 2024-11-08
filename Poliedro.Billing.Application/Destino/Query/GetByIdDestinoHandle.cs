using MediatR;
using Poliedro.Billing.Application.Destino.Dto;
using Poliedro.Billing.Domain.Destino.Ports;

namespace Poliedro.Billing.Application.Destino.Query;

public class GetByIdDestinoHandle(IDestinoRepository DestinoRepository) : IRequestHandler<GetByIdDestinoQuery, DestinoDto>
{
    public async Task<DestinoDto> Handle(GetByIdDestinoQuery request, CancellationToken cancellationToken)
    {
        var getByIdDestino = await DestinoRepository.GetById(request.Id);
        return new DestinoDto(Id: getByIdDestino.iddestino,Descripcion: getByIdDestino.descripcion);
    }
}
