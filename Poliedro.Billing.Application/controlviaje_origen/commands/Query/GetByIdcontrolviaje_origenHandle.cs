using MediatR;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Dto;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Query;

public class GetByIdcontrolviaje_origenHandle(Icontrolviaje_origenRepository controlviaje_origenRepository) : IRequestHandler<GetByIdcontrolviaje_origenQuery, controlviaje_origenDto>
{
    public async Task<controlviaje_origenDto> Handle(GetByIdcontrolviaje_origenQuery request, CancellationToken cancellationToken)
    {
        var getByIdcontrolviaje_origen = await controlviaje_origenRepository.GetById(request.Idcontrolviaje_origen);
        return new controlviaje_origenDto(idcontrolviaje_origen: getByIdcontrolviaje_origen.idcontrolviaje_origen, idcontrolviaje: getByIdcontrolviaje_origen.idcontrolviaje, idorigen:getByIdcontrolviaje_origen.idorigen, idciudad:getByIdcontrolviaje_origen.idciudad);
    }
}
