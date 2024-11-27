using MediatR;
using Poliedro.Billing.Application.categoria_documento.Dto;
using Poliedro.Billing.Domain.categoria_documento.Ports;

namespace Poliedro.Billing.Application.categoria_documento.Query;

public class GetAllActuatorHandle(Icategoria_documentoRepository _categoria_documentoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<categoria_documentoDto>>
{
    public async Task<IEnumerable<categoria_documentoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _categoria_documentoRepository.GetAllAsync();
        return entities.Select(categoria_documento => new categoria_documentoDto
        (
            Id: categoria_documento.Id,
            descripcion: categoria_documento.descripcion
           
        ));
    }
}
