using MediatR;
using Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.Producto.Ports;

namespace Poliedro.Billing.Application.Producto.Handle;

public class ProductoHandle(IProductoRepository _productoRepository) : IRequestHandler<CreateProductoCommand, bool>
{
    public async Task<bool> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        ProductoEntity producto = new() { descripcion= request.descripcion, idunidad_medida = request.idunidad_medida,};
        return await _productoRepository.SaveAsync(producto);
    }
}
