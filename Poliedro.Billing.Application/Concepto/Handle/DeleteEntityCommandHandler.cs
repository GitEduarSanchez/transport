using MediatR;
using Poliedro.Billing.Application.Estado.Commands;
using Poliedro.Billing.Domain.Concepto.Ports;

namespace Poliedro.Billing.Application.Concepto.Commands.Handle;

public class DeleteEntityCommandHandler(IConceptoRepository conceptoRepository) : IRequestHandler<DeleteConceptoCommand, bool>
{
    public async Task<bool> Handle(DeleteConceptoCommand request, CancellationToken cancellationToken)
    {
        return await conceptoRepository.DeleteAsync(request.Id);
    }
}
