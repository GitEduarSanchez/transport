using MediatR;
using Poliedro.Billing.Domain.ControlViaje.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViaje.Commands.Handle;

public class DeleteEntityCommandHandler(IControlViajeRepository controlviajeRepository) : IRequestHandler<DeleteControlViajeCommand, bool>
{
    public async Task<bool> Handle(DeleteControlViajeCommand request, CancellationToken cancellationToken)
    {
        return await controlviajeRepository.DeleteAsync(request.Id);
    }
}
