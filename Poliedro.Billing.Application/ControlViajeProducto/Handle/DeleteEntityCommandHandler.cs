using MediatR;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands.Handle;

public class DeleteEntityCommandHandler(IControlViajeProductoRepository controlViajeProductoRepository) : IRequestHandler<DeletecontrolViajeProductoCommand, bool>
{
    public async Task<bool> Handle(DeletecontrolViajeProductoCommand request, CancellationToken cancellationToken)
    {
        return await controlViajeProductoRepository.DeleteAsync(request.idControlViajeProducto);
    }
}
