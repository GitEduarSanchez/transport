using MediatR;
using Poliedro.Billing.Domain.Destino;
using Poliedro.Billing.Domain.Destino.Ports;

namespace Poliedro.Billing.Application.Destino.Commands.Handle;

public class DeleteEntityCommandHandler(IDestinoRepository paisRepository) : IRequestHandler<DeleteDestinoCommand, bool>
{
    public async Task<bool> Handle(DeleteDestinoCommand request, CancellationToken cancellationToken)
    {
        return await paisRepository.DeleteAsync(request.Id);
    }
}