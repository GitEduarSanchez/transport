using MediatR;
using Poliedro.Billing.Domain.Estado.Entities.Ports;

namespace Poliedro.Billing.Application.Estado.Commands.Handle;

public class DeleteEntityCommandHandler(IEstadoRepository estadoRepository) : IRequestHandler<DeleteEstadoCommand, bool>
{
    public async Task<bool> Handle(DeleteEstadoCommand request, CancellationToken cancellationToken)
    {
        return await estadoRepository.DeleteAsync(request.Id);
    }
}
