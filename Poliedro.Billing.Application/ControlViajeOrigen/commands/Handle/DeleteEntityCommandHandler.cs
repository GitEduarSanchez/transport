using MediatR;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Handle;

public class DeleteEntityCommandHandler(IControlViajeOrigenRepository controlviajeorigenRepository) : IRequestHandler<DeleteControlViajeOrigenCommand, bool>
{
    public async Task<bool> Handle(DeleteControlViajeOrigenCommand request, CancellationToken cancellationToken)
    {
        return await controlviajeorigenRepository.DeleteAsync(request.Id);
    }
}
