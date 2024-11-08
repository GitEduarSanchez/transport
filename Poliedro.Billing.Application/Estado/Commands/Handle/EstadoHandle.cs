using MediatR;
using Poliedro.Billing.Application.Estado.Commands;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Estado.Entities.Ports;

namespace Poliedro.Billing.Application.Estado.Commands.Handle;

public class EstadoHandle(IEstadoRepository _estadoRepository) : IRequestHandler<CreateEstadoCommand, bool>
{
    public async Task<bool> Handle(CreateEstadoCommand request, CancellationToken cancellationToken)
    {
        EstadoEntity estado = new() { Descripcion = request.descripcion };
        return await _estadoRepository.SaveAsync(estado);
    }
}
