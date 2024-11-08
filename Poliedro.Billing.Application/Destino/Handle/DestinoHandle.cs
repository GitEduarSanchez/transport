using MediatR;
using Poliedro.Billing.Application.Destino.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Destino.Entities;
using Poliedro.Billing.Domain.Destino.Ports;

namespace Poliedro.Billing.Application.Destino.Handle;

public class DestinoHandle(IDestinoRepository _DestinoRepository) : IRequestHandler<CreateDestinoCommand, bool>
{
    public async Task<bool> Handle(CreateDestinoCommand request, CancellationToken cancellationToken)
    {
        DestinoEntity Destino = new() { descripcion = request.Descripcion };
        return await _DestinoRepository.SaveAsync(Destino);
    }
}
