using MediatR;
using Poliedro.Billing.Application.ControlViajeProducto.Commands;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;

namespace Poliedro.Billing.Application.ControlViajeProducto.Handle;

public class ControlViajeProductoHandle(IControlViajeProductoRepository _ControlViajeProductoRepository) : IRequestHandler<CreateControlViajeProductoCommand, bool>
{
    public async Task<bool> Handle(CreateControlViajeProductoCommand request, CancellationToken cancellationToken)
    {
        ControlViajeProductoEntity controlViajeProducto = new() { idControlViaje = request.idControlViaje, idProducto = request.idProducto };
        return await _ControlViajeProductoRepository.SaveAsync(controlViajeProducto);
    }
}
