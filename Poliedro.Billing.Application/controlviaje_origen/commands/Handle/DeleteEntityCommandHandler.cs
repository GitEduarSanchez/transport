using MediatR;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Handle;

public class DeleteEntityCommandHandler(Icontrolviaje_origenRepository controlviaje_origenRepository) : IRequestHandler<Deletecontrolviaje_origenCommand, bool>
{
    public async Task<bool> Handle(Deletecontrolviaje_origenCommand request, CancellationToken cancellationToken)
    {
        return await controlviaje_origenRepository.DeleteAsync(request.Id);
    }
}
