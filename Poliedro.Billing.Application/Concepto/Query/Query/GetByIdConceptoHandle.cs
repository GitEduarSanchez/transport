using MediatR;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Domain.Concepto.Ports;

namespace Poliedro.Billing.Application.Concepto.Query.Query;

public class GetByIdConceptoHandle(IConceptoRepository conceptoRepository) : IRequestHandler<GetByIdConceptoQuery, ConceptoDto>
{
    public async Task<ConceptoDto> Handle(GetByIdConceptoQuery request, CancellationToken cancellationToken)
    {
        var getByIdConcepto = await conceptoRepository.GetById(request.IdDescripcion);
        return new ConceptoDto(IdConcepto: getByIdConcepto.IdConcepto, descripcion: getByIdConcepto.descripcion);
    }
}
