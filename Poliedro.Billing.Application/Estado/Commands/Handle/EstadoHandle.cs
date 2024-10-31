using MediatR;
using Poliedro.Billing.Application.Estado.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Estado.Ports;

namespace Poliedro.Billing.Application.Estado.Handle;

public class EstadoHandle(IEstadoRepository _estadoRepository) : IRequestHandler<CreateEstadoCommand, bool>
{
    public async Task<bool> Handle(CreateEstadoCommand request, CancellationToken cancellationToken)
    {
        EstadoEntity estado = new() { Descripcion = request.descripcion };
        return await _estadoRepository.SaveAsync(estado);
    }
}
