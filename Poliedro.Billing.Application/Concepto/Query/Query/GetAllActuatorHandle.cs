using MediatR;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Domain.Concepto.Ports;

namespace Poliedro.Billing.Application.Concepto.Query.Query;

public class GetAllConceptoHandle(IConceptoRepository _conceptoRepository) : IRequestHandler<GetAllConceptoQuery, IEnumerable<ConceptoDto>>
{
    public async Task<IEnumerable<ConceptoDto>> Handle(GetAllConceptoQuery request, CancellationToken cancellationToken)
    {
        var entities = await _conceptoRepository.GetAllAsync();
        return entities.Select(concepto => new ConceptoDto
        (
            IdConcepto: concepto.IdConcepto,
            descripcion: concepto.descripcion
        ));
    }
}
