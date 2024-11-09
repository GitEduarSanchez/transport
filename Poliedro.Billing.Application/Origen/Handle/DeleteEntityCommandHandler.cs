using MediatR;
using Poliedro.Billing.Domain.Origen.Entities.Ports;


namespace Poliedro.Billing.Application.Origen.Commands.Handle;

public class DeleteEntityCommandHandler(IOrigenRepository origenRepository) : IRequestHandler<DeleteOrigenCommand, bool>
{
    public async Task<bool> Handle(DeleteOrigenCommand request, CancellationToken cancellationToken)
    {
        return await origenRepository.DeleteAsync(request.Id);
    }
}
