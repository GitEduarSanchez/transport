using MediatR;
using Poliedro.Billing.Application.Concepto.Commands.Query;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Domain.Concepto.Ports;


namespace Poliedro.Billing.Application.Estado.Commands.Query;

public class GetByIdConceptoHandle(IConceptoRepository conceptoRepository) : IRequestHandler<GetByIdConceptoQuery, ConceptoDto>
{
    public async Task<ConceptoDto> Handle(GetByIdConceptoQuery request, CancellationToken cancellationToken)
    {
        var getByIdConcepto = await conceptoRepository.GetById(request.idConcepto);
        return new ConceptoDto( idConcepto: getByIdConcepto.idConcepto, descripcion: getByIdConcepto.descripcion);
    }
}
 