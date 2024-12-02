using MediatR;
using Poliedro.Billing.Application.CategoriaDocumento.Dto;
using Poliedro.Billing.Domain.CategoriaDocumento.Ports;

namespace Poliedro.Billing.Application.CategoriaDocumento.Query;

public class GetAllActuatorHandle(ICategoriaDocumentoRepository _CategoriaDocumentoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<CategoriaDocumentoDto>>
{
    public async Task<IEnumerable<CategoriaDocumentoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _CategoriaDocumentoRepository.GetAllAsync();
        return entities.Select(CategoriaDocumento => new CategoriaDocumentoDto
        (
            Id: CategoriaDocumento.Id,
            descripcion: CategoriaDocumento.descripcion
           
        ));
    }
}
