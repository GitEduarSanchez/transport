using MediatR;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Domain.Concepto.Ports;


namespace Poliedro.Billing.Application.Concepto.Commands.Query;

public class GetAllActuatorHandle(IConceptoRepository _conceptoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<ConceptoDto>>
{
    public async Task<IEnumerable<ConceptoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _conceptoRepository.GetAllAsync();
        return entities.Select(concepto => new ConceptoDto
        (
            idConcepto: concepto.idConcepto,
            descripcion: concepto.descripcion
        ));
    }
}
