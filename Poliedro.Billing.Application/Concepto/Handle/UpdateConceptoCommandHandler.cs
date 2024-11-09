using MediatR;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Concepto.Ports;


namespace Poliedro.Billing.Application.Concepto.Commands.Handle;

public class UpdateConceptoCommandHandler(IConceptoRepository _conceptoRepository) : IRequestHandler<UpdateConceptoCommand, Unit>
{
    public async Task<Unit> Handle(UpdateConceptoCommand request, CancellationToken cancellationToken)
    {
        var concepto = await _conceptoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        concepto.descripcion = request.ConceptoEntity.Descripcion;
        await _conceptoRepository.UpdateAsync(request.Id, new ConceptoEntity() { descripcion = concepto.descripcion});
        return Unit.Value;
    }
}
