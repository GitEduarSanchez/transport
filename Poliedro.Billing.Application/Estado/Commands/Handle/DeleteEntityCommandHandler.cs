using MediatR;
using Poliedro.Billing.Domain.pais.Entities.Ports;

namespace Poliedro.Billing.Application.pais.Commands.Handle;

public class DeleteEntityCommandHandler(IpaisRepository paisRepository) : IRequestHandler<DeletepaisCommand, bool>
{
    public async Task<bool> Handle(DeletepaisCommand request, CancellationToken cancellationToken)
    {
        return await paisRepository.DeleteAsync(request.Id);
    }
}
