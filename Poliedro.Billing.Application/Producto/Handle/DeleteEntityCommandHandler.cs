using MediatR;
using Poliedro.Billing.Domain.Producto.Entities.Ports;

namespace Poliedro.Billing.Application.Producto.Commands.Handle;

public class DeleteEntityCommandHandler(IProductoRepository ProductoRepository) : IRequestHandler<DeleteProductoCommand, bool>
{
    public async Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {
        return await ProductoRepository.DeleteAsync(request.Id);
    }
}
