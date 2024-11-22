using MediatR;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.Producto.Entities.Ports;

namespace Poliedro.Billing.Application.Producto.Commands.Handle;

public class UpdateProductoCommandHandler(IProductoRepository _ProductoRepository) : IRequestHandler<UpdateProductoCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {
        var Producto = await _ProductoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        Producto.descripcion = request.ProductoEntity.Descripcion;
        await _ProductoRepository.UpdateAsync(request.Id, new ProductoEntity() { descripcion = Producto.descripcion});
        return Unit.Value;
    }
}
