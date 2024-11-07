using MediatR;
using Poliedro.Billing.Application.Concepto.Commands;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Concepto.Ports;

namespace Poliedro.Billing.Application.Concepto.Handle;

public class ConceptoHandle(IConceptoRepository _ConceptoRepository) : IRequestHandler<CreateConceptoCommand, bool>
{
    public async Task<bool> Handle(CreateConceptoCommand request, CancellationToken cancellationToken)
    {
        ConceptoEntity Concepto = new() { descripcion = request.descripcion };
        return await _ConceptoRepository.SaveAsync(Concepto);
    }
}
