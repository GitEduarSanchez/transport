using MediatR;
using Poliedro.Billing.Application.unidad_medida.Dto;
using Poliedro.Billing.Domain.unidad_medida.Ports;

namespace Poliedro.Billing.Application.unidad_medida.Query;

public class GetByIdunidad_medidaHandle(Iunidad_medidaRepository unidad_medidaRepository) : IRequestHandler<GetByIdunidad_medidaQuery, unidad_medidaDto>
{
    public async Task<unidad_medidaDto> Handle(GetByIdunidad_medidaQuery request, CancellationToken cancellationToken)
    {
        var getByIdunidad_medida = await unidad_medidaRepository.GetById(request.Id);
        return new unidad_medidaDto(Id: getByIdunidad_medida.Id, descripcion: getByIdunidad_medida.descripcion);
    }
}
