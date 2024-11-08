using MediatR;
using Poliedro.Billing.Application.Ciudad.Dto;
using Poliedro.Billing.Domain.Ciudad.Ports;

namespace Poliedro.Billing.Application.Ciudad.Query;

public class GetByIdCiudadHandle(ICiudadRepository ciudadRepository) : IRequestHandler<GetByIdCiudadQuery, CiudadDto>
{
    public async Task<CiudadDto> Handle(GetByIdCiudadQuery request, CancellationToken cancellationToken)
    {
        var getByIdCiudad = await ciudadRepository.GetById(request.Id);
        return new CiudadDto(Id: getByIdCiudad.Id, Descripcion: getByIdCiudad.Descripcion,Iddepartamento: getByIdCiudad.Iddepartamento);
    }
}
